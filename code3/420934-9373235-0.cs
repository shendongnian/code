    public class MagTekIPAD : ICardReader
    {
      private readonly Func<ICreditCardInfo> factory;
      public MagTekIPAD(Func<ICreditCardInfo> factory)
      {
        this.factory = factory;
      }
      public ICreditCardInfo GetCardInfo()
      {
        var info = factory();
        ...
        return info;
      }
    }
