      try {
        int c = a / b;
      }
      catch (Exception) { // <- Never ever do this!
        Console.WriteLine("Oh NO!!");
      }
