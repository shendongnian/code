    public static class HelperClass
    {
        static HelperClass()
        {
            var config = ServiceLocator.Get<IConfig>();
            UserId = config.Get("UserId");
        }
        public static int UserId { get; private set; }
    }
