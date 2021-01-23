    static double moneyamount = 0;
    static void SelectProduct() {
        moneyamount = 0;
        int selection = int.Parse(Console.ReadLine());
        if (selection == 1) {
            moneyamount = 1.50;       
        }
        else {
            Console.WriteLine("Wrong Selection");
        }
        Console.WriteLine("Your drink costs $" + moneyamount);
        InsertCoin();
    }
    static void InsertCoin() {
        Console.WriteLine("Balance of cost $" + moneyamount);
    }
