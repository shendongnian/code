    public class ILogFactory
    {
      public ILog Create(CountryCode code)
      {
         if(code == CountryCode.GBR) return new EvenLogger();
    
         if(code == CountryCode.UK) return new DatabaseLogger(_providerFactory());
    
         ///etc...
      }
    }
