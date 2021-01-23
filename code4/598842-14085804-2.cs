       static int y;
       static void fn1()
       {
           Console.WriteLine(x++);
           fn1();
           Console.WriteLine(y++);
       }
