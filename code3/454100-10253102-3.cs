     static int ObtainInput(string prompt, bool canBeZero)
     {
         while(true) // loop forever!
         {
             Console.Write(prompt);
             string input = Console.ReadLine();
             int result;
             bool success = int.TryParse(input, out result);
             if (success && (canBeZero || result != 0))
                 return result;
             Console.WriteLine("Invalid input!");
         }
     }
