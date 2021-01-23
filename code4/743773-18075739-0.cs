        static void Main(string[] args)
        {
          int[] userInput = new int[100];
          string recievedInput = "";  
        for (int i = 0; i<userInput.Length; i++)
        {
            recievedInput = Console.ReadLine();
            int.TryParse(recievedInput, out userInput[i]);
            if (recievedInput == "")
                break;
        }
        Console.WriteLine (userInput); //this will only print the type name of Userinput not all element  
        }
