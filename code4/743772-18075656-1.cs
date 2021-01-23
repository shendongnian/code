      public static void Main(string[] args)
      {
         int[] userInput = new int[100];
         int counter = 0;
         for (counter = 0; counter < userInput.Length; counter++)
         {
            string input = Console.ReadLine();
            if (input == "")
               break;
            else
               int.TryParse(input, out userInput[counter]);
         }
         for (int i = 0; i < counter; i++)
         {
            Console.WriteLine(userInput[i]);            
         }
         Console.ReadLine();
      }
