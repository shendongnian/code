    static double MoneyAmount
    {get; set;}
    
    static void SelectProduct() 
    {
        MoneyAmount= 0;
    
        int selection = int.Parse(Console.ReadLine());
        if (selection == 1) {
            MoneyAmount = 1.50;       
        }
    
        else {
            Console.WriteLine("Wrong Selection");
        }
    
        Console.WriteLine("Your drink costs $" + MoneyAmount);
        InsertCoin();
    }
    
    static void InsertCoin() 
    {
        Console.WriteLine("Balance of cost $" + MoneyAmount);
    }
