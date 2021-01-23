     Sum(doubleNumbers);
     private static void Sum(params double[] list)
     {
         double sum = 0;
         foreach (double number in list)
         {
             sum += number;
         }
         Console.WriteLine(sum);
     }
