    using System;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                DateTime then = new DateTime(2013, 1, 30, 0, 1, 3);
                TimeSpan ts = DateTime.Now - then;
                Console.WriteLine(ts.ToString());
                Console.WriteLine(ts.ToString(@"hh\:mm\:ss"));
                Console.WriteLine(string.Format(@"{0:hh\:mm\:ss}", ts));
                // Or, with rounding:
                TimeSpan rounded = TimeSpan.FromSeconds((int)(0.5 + ts.TotalSeconds));
                Console.WriteLine(rounded.ToString(@"hh\:mm\:ss"));
            }
        }
    }
