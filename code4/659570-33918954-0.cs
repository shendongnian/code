     class Program
     {
      static void Main(string[] args)
      {
         const int ARRAY_SIZE = 5;
         int[] ArrayTable = new int[ARRAY_SIZE];
         int Element=0;
         int a;
         for(a=0; a<ArrayTable.Length;a++)
         {
            Console.Write("Please Enter an integer (between 10-100): ");
            Element = Int32.Parse(Console.ReadLine());
            while (Element < 10 || Element > 100)
            {
               Console.Write("Try again (between 10-100): ");
               Element = Int32.Parse(Console.ReadLine());
            }
            ArrayTable[a] = Element;
            for (int b = 0; b < a; b++)
            {
               while (ArrayTable[a] == ArrayTable[b])
               {
                  Console.Write("Integer Duplicated!\nTry again: ");
                  Element = Int32.Parse(Console.ReadLine());
                  ArrayTable[a] = Element;
                  Console.WriteLine();
                  while (Element < 10 || Element > 100)
                  {
                     Console.Write("Try again (between 10-100): ");
                     Element = Int32.Parse(Console.ReadLine());
                     ArrayTable[a] = Element;
                  }
               }
            }
         }
         for (int c = 0; c < ArrayTable.Length; c++)
         {
            Console.Write("{0} ", ArrayTable[c]);
         }
      }
