     static void Main(string[] args)
     {
         Console.Write("Give a number from 1 to 20: ");
         int n = int.Parse(Console.ReadLine());
         int row,col;
         Console.WriteLine("");
         if (n > 0 && n < 21)
         {
             for (row = 1; row <= n; row++)
             {
                 for (col = row; col <= row + n - 1;col++ )
                 {
                     Console.Write(col + " ");
                 }
                 
                 Console.WriteLine();
             }
         }
         else
         {
             Console.WriteLine("This number is greater than 20 or smaller than 1");
         }
     }
