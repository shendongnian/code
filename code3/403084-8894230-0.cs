    public class Caller
    {
        private readonly Func<string> factory;
        public Caller()
        {
            this.factory = Service.GetFunc();
        }
    }
    public class Service
    {
        public static Func<string> GetFunc()
        {
            return () => Guid.NewGuid().ToString();
        }
    }
