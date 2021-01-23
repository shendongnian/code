    namespace ConsoleApplication9
    {
      using System.Collections.Generic;
      using System.Threading.Tasks;
      class Program
      {
        static void Main()
        {
          var numbers = new List<int>();
          for(int a=0;a<=70;a++)
          {
            for(int b=0;b<=6;b++)
            {
              for(int c=0;c<=10;c++)
              {
                var unmodifiedA = a;
                var unmodifiedB = b;
                var unmodifiedC = c;
                Task.Factory.StartNew(() => MyMethod(numbers, unmodifiedA, unmodifiedB, unmodifiedC));
              }
            }
          }
        }
        private static void MyMethod(List<int> nums, int a, int b, int c)
        {
          //Really a lot of stuffs here
        }
      }
    }
