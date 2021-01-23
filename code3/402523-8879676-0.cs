    public interface IPaymentProvider
    {
      void Pay()
    }
    
    // Implementations of IPaymentProvider for PaypalPaymentProvider & WorldpayPaymentProvider
    
    public static class PaymentHelper
    {
        private static var providers = Dictionary<String,IPaymentProvider>
        {
            {"paypal",new PaymentProviderPaypal()},
            {"worldpay",new PaymentProviderWorldpay()}
        }
    
    
        public static void Pay(string provider)
        {
            if(!providers.Containskey(provider))
                throw new InvalidOperationException("Invalid provider: " + provider);
    
            providers[provider].Pay();
        }
    
    }
