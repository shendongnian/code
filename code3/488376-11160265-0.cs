    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private const int TaskCount = 15;
    
            static void Main(string[] args)
            {
                var tasks = new Task[TaskCount];
                for (var index = 0; index < TaskCount; index++)
                {
                    tasks[index] = Task.Factory.StartNew(Method);
                }
                Task.WaitAll(tasks);
    
                Console.WriteLine("Some text");
            }
    
            private static void Method()
            {
                for (int i = 0; i < 15; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
