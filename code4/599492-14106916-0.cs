    static void Main(string[] args)
    {
       int[] numCheck = new int[10];
       Console.WriteLine("Please enter 10 numbers: ");
       for (int i = 0; i < 10; i++)
       {
           Console.Write("Number {0}: ", i + 1);
           numCheck[i] = int.Parse(Console.ReadLine());
       }
    
       Console.WriteLine("Please enter any number to check if the number already exist");
       int userInput = int.Parse(Console.ReadLine());
       for (int i = 0; i < 10; i++)
       {
           if (userInput == numCheck[i])
           {
               Console.Write("FOUND NUMBER");
               break;
           }
       }
    }
