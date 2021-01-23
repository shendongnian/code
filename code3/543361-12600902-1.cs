    public class HelperClass
    {
        public HelperClass(IConfig config)
        {
            UserId = config.Get("UserId");
        }
        public int UserId { get; private set; }
    }
