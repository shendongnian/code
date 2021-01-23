        List<int> moneys = new List<int>();
        Console.WriteLine("Please enter the cost of your choice");
        try
        {
           int money = int.Parse(Console.ReadLine());
               moneys.Add(money);
        }
        catch(FormatException nfe)
        {
          Debug.WriteLine(nfe.Message);
        }
