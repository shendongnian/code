    class BusinessService : IChargable<ServiceCharge>
    {
        public ServiceCharge Charge()
        {
            return new ServiceCharge(...
        }
    }
    class Product : IChargable<Sale>
    {
        public Sale Charge()
        {
            return new Sale(...
        }
    }
