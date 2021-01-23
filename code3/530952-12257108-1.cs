      Console.Writeline("Enter Item Prices\n");
      List<double> items = new List<double>();
      for (double i = 0; i < 100; i++)
      {
           string userInput;
           double newItem;
           // repeatedly ask for input from the user until it's a valid double
           do 
           {
               Console.Write(string.Format("Enter item #{0}: ", i));
               // read from console into userInput
               userInput = Console.ReadLine();
           } while (!double.TryParse(userInput, out newItem))
           // add the new item to the array
           items.Add(newItem);
      }
      // output all the items to the console, separated by commas
      Console.WriteLine(
          string.Join(", ", 
              items.Select(item => item.ToString())
          )
      );
