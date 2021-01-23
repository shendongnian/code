    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            private static void Main(string[] args)
            {
                Console.WriteLine("Starting");
                CreateTask(1);
                CreateTask(2);
                Console.ReadKey();
            }
            private static void CreateTask(int taskId)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 10; ++i)
                    {
                        int randomNumber = _random.Next(0, 50);
                        Console.WriteLine("Thread {0}, setting value {1}", taskId, randomNumber);
                        _concurrency.Value = randomNumber;
                        // Thread.Sleep(10); // Try with this sleep uncommented.
                        int test = _concurrency.Value;
                        Console.WriteLine("Thread {0}, getting value {1}", taskId, test);
                        if (test != randomNumber)
                        {
                            Console.WriteLine("Number mismatch.");
                        }
                        Thread.Sleep(_random.Next(5, 15));
                    }
                });
            }
            private static Random _random = new Random();
            private static Concurrency _concurrency = new Concurrency();
        }
        class Concurrency
        {
            private int _myValue;
            private object _locker = new object();
            public int Value
            {
                set
                {
                    lock (_locker)
                    {
                        _myValue = value;
                        Thread.Sleep(_random.Next(5, 25));
                    }
                }
                get
                {
                    return _myValue;
                }
            }
            static Random _random = new Random();
        }
    }
