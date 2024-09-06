//using System;
//using System.IO;
//using System.Threading;

//class Program
//{
//    static string file = "log.txt";
//    static object l = new object();

//    static void Main()
//    {
//        while (true)
//        {
//            Console.WriteLine("1. Создать файл и записать данные");
//            Console.WriteLine("2. Прочитать данные из файла");
//            Console.WriteLine("3. Записать данные параллельно через потоки");
//            Console.WriteLine("4. Удалить файл");
//            Console.WriteLine("5. Выход");
//            Console.Write("Введите номер команды: ");
//            var k = Console.ReadLine();

//            switch (k)
//            {
//                case "1":
//                    CreateFile();
//                    break;
//                case "2":
//                    ReadFile();
//                    break;
//                case "3":
//                    ParallelWrite();
//                    break;
//                case "4":
//                    DeleteFile();
//                    break;
//                case "5":
//                    return; // Выход из программы
//                default:
//                    Console.WriteLine("Неверная команда.");
//                    break;
//            }
//        }
//    }

//    // Метод создания файла и записи 10 строк с текущей датой и временем
//    static void CreateFile()
//    {
//        if (File.Exists(file))
//        {
//            File.Delete(file);
//            Console.WriteLine("Старый файл удален.");
//        }

//        using (StreamWriter writer = new StreamWriter(file))
//        {
//            for (int i = 1; i <= 10; i++)
//            {
//                writer.WriteLine($"ПОТОК {i}: {DateTime.Now}");
//            }
//        }
//        Console.WriteLine("Файл создан и 10 ПОТОКА записаны.");
//    }

//    // Метод чтения файла и вывода содержимого в консоль
//    static void ReadFile()
//    {
//        if (File.Exists(file))
//        {
//            Console.WriteLine("Содержимое файла:");
//            Console.WriteLine(File.ReadAllText(file));
//        }
//        else
//        {
//            Console.WriteLine("Файл не существует.");
//        }
//    }

//    // Метод параллельной записи с использованием потоков
//    static void ParallelWrite()
//    {
//        if (File.Exists(file))
//        {
//            File.Delete(file);
//            Console.WriteLine("Старый файл удален.");
//        }

//        Thread t1 = new Thread(() => WriteThread(1));
//        Thread t2 = new Thread(() => WriteThread(2));

//        t1.Start();
//        t2.Start();

//        t1.Join();
//        t2.Join();

//        Console.WriteLine("Данные записаны двумя потоками.");
//    }

//    // Метод записи данных из потока
//    static void WriteThread(int threadNumber)
//    {
//        lock (l)
//        {
//            using (StreamWriter writer = new StreamWriter(file, true))
//            {
//                for (int i = 1; i <= 5; i++)
//                {
//                    writer.WriteLine($"Поток {threadNumber}: Запись выполнена в {DateTime.Now:HH:mm:ss}");
//                    Thread.Sleep(100); // Небольшая задержка для демонстрации параллельности
//                }
//            }
//        }
//    }

//    // Метод удаления файла
//    static void DeleteFile()
//    {
//        if (File.Exists(file))
//        {
//            File.Delete(file);
//            Console.WriteLine("Файл удален.");
//        }
//        else
//        {
//            Console.WriteLine("Файл не существует.");
//        }
//    }
//}
