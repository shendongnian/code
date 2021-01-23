    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                var task = new Task<int>(() => test(1000, "Test1"));
                tryTask(task);
                task = new Task<int>(() => test(2000, "Test2"));
                tryTask(task);
                task = new Task<int>(() => test(1, "Test2"));
                tryTask(task);
            }
            static void tryTask(Task<int> task)
            {
                task.Start();
                try
                {
                    Console.WriteLine("Task result = " + task.Result);
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("Task threw an exception: " + ex.InnerException.Message);
                }
            }
            static int test(int value, string name)
            {
                Console.WriteLine("Starting thread " + name);
                Thread.Sleep(value);
                Console.WriteLine("Ending thread " + name);
                if (value == 1) // Magic number!
                {
                    throw new InvalidOperationException("Test Exception");
                }
                return value;
            }
        }
    }
