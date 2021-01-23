    using System;
    using System.Threading;
    namespace Demo
    {
        class Program
        {
            private static void Main(string[] args)
            {
                SecondaryThreadClass instance = new SecondaryThreadClass();
                instance.DoJobAsync();
                Console.WriteLine("Press a key to GC.Collect()");
                Console.ReadKey();
                instance = null;
                GC.Collect();
                Console.WriteLine("Press a key to exit.");
                Console.ReadKey();
            }
        }
        public class SecondaryThreadClass
        {
            private string str;
            public SecondaryThreadClass()
            {
            }
            ~SecondaryThreadClass()
            {
                Console.WriteLine("Secondary class's instance was destroyed");
            }
            public void DoJobAsync()
            {
                new Thread(() =>
                {
                    this.str = "Hello world";
                    Console.WriteLine(this.str);
                }).Start();
            }
        }
    }
