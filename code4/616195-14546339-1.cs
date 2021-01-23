    public sealed class PayPalFactory
    {
        public IPayPal Create()
        {
            if(EnvironmentIsLive) // replace this with a proper check!
                return new PayPal();
            else
                return new SandboxPayPal();
        }
    }
