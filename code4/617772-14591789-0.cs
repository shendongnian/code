    namespace ConsoleApplication1
    {
      using System;
      using System.Text;
      class Program
      {
        static void Main(string[] args)
        {
          Random random = new Random();
          string[] myStrings = new string[] { "aaa", "bbb", "ccc", "ddd" };
          for (int n = 0; n < 10; n++)
          {
            int rnd = random.Next(0, myStrings.Length);
            string s = myStrings[rnd];
            Console.WriteLine("-> {0}", s);
          }
          Console.ReadLine();
        }
      }
    }
