      Console.Writeline("Enter Item Prices\n");
      List<double> items = new List<double>();
      for (double i = 0; i < 100; i++)
      {
           // read from console into userInput
           string userInput = Console.ReadLine();
           // parse userInput into a double (will throw an Exception if not a valid double)
           double newItem = double.Parse(userInput);
           // add the new item to the array
           items.Add(newItem);
      }
      // output all the items to the console, separated by commas
      Console.WriteLine(
          string.Join(", ", 
              items.Select(item => item.ToString())
          )
      );
