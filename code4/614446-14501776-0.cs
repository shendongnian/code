    public abstract class Driver
    {
        public abstract DriverIdentity Identity { get; }
        public abstract DriverOperation Operation { get; }
    
        protected abstract DriverUtility Utility { get; }
    }
