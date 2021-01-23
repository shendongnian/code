    static void Main(string[] args)
    {
        string resp = "";
        string price, discount;
        decimal discountedPrice, savedAmount;
        do {
            .... // your previous code here
            ....
            Console.WriteLine("The discounted price of this item is: ${0}\nYou saved: ${1}", discountedPrice, savedAmount);
            Console.WriteLine("Another item?");
            string resp = Console.ReadLine().ToLower();
        }
        while (resp == "y" || resp == "yes");
        Console.ReadLine();
    }
