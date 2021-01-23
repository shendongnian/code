    static int readValue(string strPrompt) {
      int intRes = 0;
      bool done = false;
      while (!done) {
        Console.WriteLine(strPrompt);
        if (Int32.TryParse(Console.ReadLine(), out intRes) {
          done = true;
        } else {
          Console.WriteLine("Please enter a numeric value.\n");
        }
      }
      return intRes;    
    }
