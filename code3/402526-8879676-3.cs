    public interface IPaymentProvider
    {
      void Pay(double amount);
    }
    public static void Pay(string provider, double amount)
    {
        if(!providers.Containskey(provider))
            throw new InvalidOperationException("Invalid provider: " + provider);
        providers[provider].Pay(amount);
    }
