    static void Main(string[] args)
    {
        Taxpayer[] taxArray = new Taxpayer[5];
        // Implement a for-loop that will prompt the user to enter
        // the Social Security Number and gross income.
        ...
        Rates taxRates = Taxpayer.GetRates();
        // Implement a for-loop that will display each object as formatted 
        // taxpayer SSN, income and calculated tax.
        for (int i = 0; i < taxArray.Length; ++i)
        {
            Console.WriteLine(
                "Taxpayer # {0} SSN: {1}, Income is {2:c}, Tax is {3:c}",
                i + 1, 
                taxArray[i].SSN, 
                taxArray[i].grossIncome,
                taxRates.CalculateTax(50000));
        } 
        ...
    }
