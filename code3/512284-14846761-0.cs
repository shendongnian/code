    public void DoFizzBuzz()
       {
           for (int i = 1; i < 101; i++)
           {
               if ((i % 3 == 0) && (i % 5 == 0))
               {
                   Console.WriteLine("{0} FizzBuzz", i);
               }
               else if (i % 3 == 0)
               {
                   Console.WriteLine("{0} Fizz", i);
               }
               else if (i % 5 == 0)
               {
                   Console.WriteLine("{0} Buzz", i);
               }
               else
               {
                   Console.WriteLine(i);
               }
           }
           Console.ReadLine();
       }
