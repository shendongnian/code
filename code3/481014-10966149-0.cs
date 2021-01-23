    static void ReadMenuInput<T>(out T menuInput) where T : struct
    {           
      while (true)
      {
        if (Enum.TryParse<T>(Console.ReadLine(), out menuInput)
         && Enum.IsDefined(typeof(T), menuInput))
        {
          break;
        }
        
        Console.WriteLine("Please enter a valid input.");
      } 
    }
