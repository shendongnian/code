    public static List<int> AskUserForNumbers()
    {
      List<int> numbers = new List<int>();
    
      while(...)//todo determine end condition
      {
        string userInput = Console.ReadLine();
        if(...)//todo determine if user is done
        {
    
        }
        else
        {
          int nextNumber = ...;//todo parse user input
          numbers.Add(nextNumber);
        }
      }
      return numbers;
    }
