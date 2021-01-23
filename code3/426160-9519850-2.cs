    int maxNumber = n;
    timer timer;
    Dictionary<int, int> numbers
    int timerTicks;
    // Set up numbers with 0 base rating
    SetUpDetails()
    {
      timer.interval = i
      for (int i = 0; i < maxNumber; i++)
        numbers.Add(i, 0);
    }
    timer.Tick
    {
      // List with numbers
      List<int> numbersToChooseFrom;
      foreach (KeyValuePair number in numbers)
      {
        // Must be added at least once
        numbersToChooseFrom.Add(number.Key)
        if (number.Value > timerTicks)
          for (int i = 0; i < (number.Value/timerTicks); i++
            // i.e. if number hasnt been chosen for 
            // timerTicks iterations give it more weight
            numbersToChooseFrom.Add(number.Key) 
        
        // Some numbers occur more than once and thus have greater chance
        int choice = ChooseRandomNumber(between 0 and numbersToChooseFrom.Length)
        int RandomNumber = numbersToChooseFrom.ElementAt(choice)
        return RandomNumber;
      }
    }
        
      
    
