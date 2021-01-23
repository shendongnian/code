        Console.WriteLine("How many students would you like to enter?");
        var read = Console.ReadLine();
        int amount;
        if(int.TryParse(read,out amount)) {
          Console.WriteLine("{0} {1}", "amount equals", amount);
          for (int i=0; i < amount; i++)
          {
            Console.WriteLine("Input the name of a student");
            String StudentName = Console.ReadLine();
            Console.WriteLine("the Students name is " + StudentName);
          }
        }
