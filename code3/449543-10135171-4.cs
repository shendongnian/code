    void SetRates()
    {
        Rates rates = new Rates(10000, 0.3, 0.4);
    }
    void UseRates(Taxpayer taxpayer)
    {
        taxpayer.Tax = new Rates().CalculateTax(taxpayer.Income);
    }
    void Main()
    {
        SetRates();                              // creates an object and throws it away
        Taxpayer taxpayer = new Taxpayer(20000);
        UseRates(taxpayer);                      // creates a new object with default values
        Console.WriteLine(taxpayer.Tax);
    }
