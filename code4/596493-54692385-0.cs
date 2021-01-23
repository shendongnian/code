     using System.Diagnostics;
     class Program
     {
        static void Test1()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test1 " + i);
            }
        }
      static void Main(string[] args)
        {
           
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Test1();
            sw.Stop();
            Console.WriteLine("Time Taken-->{0}",sw.ElapsedMilliseconds);
       }
     }
