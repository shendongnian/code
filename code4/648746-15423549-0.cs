    do
    {
      Console.WriteLine("Please enter the amount in Euro you want converted into Sterling");
      amount = double.Parse(Console.ReadLine()); 
    } while (amount <= 0.0);
    total = amount * cur1;
    Console.WriteLine("The amount of {0} Euros in Sterling at exchange rate {1} is = {2}", amount, cur1, total);
    Console.WriteLine("Press return to go back to the Menu");
    Console.ReadKey();
