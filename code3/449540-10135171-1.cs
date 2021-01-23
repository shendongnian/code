    Rates GetRates()
    {
        return new Rates(10000, 0.3, 0.4);
    }
    void UseRates(Taxpayer taxpayer, Rates rates)
    {
        taxpayer.Tax = rates.CalculateTax(taxpayer.Income);
    }
    void Main()
    {
        Rates rates = GetRates();
        Taxpayer taxpayer = new Taxpayer(20000);
        UseRates(taxpayer, rates);
        Console.WriteLine(taxpayer.Tax);
    }
    
