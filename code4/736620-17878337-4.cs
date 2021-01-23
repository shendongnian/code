    public class Currency
    {
      private Currency(string name)
      {
        Name = name;
      }
    
      public string Name {get; private set;}
      public decimal Rate {get; private set;}
    
      private void SetRate(decimal rate)
      {
        Rate = rate;
        OnRateChanged(this);
      }
    
      public static event EventHandler RateCanged;
      private static OnRateChanged(Currency currency)
      {
        var handler = RateChanged;
        if(handler != null)
        {
          handler(currency, EventArgs.Empty);
        }
      }
    
      private Dictionary<string, Currency> currencies = new Dictionary<string, Currency>();
    
      public static Currency GetCurrency(string name)
      {
        Currency currency;
        if(!currencies.TryGetValue(name, out currency))
        {
          currency = new Currency(name);
          currencies[name] = currency;
        } 
      }
    }
