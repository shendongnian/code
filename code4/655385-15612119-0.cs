    using System;
    namespace Demo
    {
        public static class Program
        {
            [STAThread]
            public static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("In try");
                    Environment.FailFast("Aaaaaargh");
                }
                finally
                {
                    Console.WriteLine("In finally");
                }
            }
        }
    }
