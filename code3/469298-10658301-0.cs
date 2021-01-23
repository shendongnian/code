    internal static class Common
    {
        internal static int TimeOut;
        internal static string Name;
    
        static Common()
        {
            TimeOut = Config.Read("timeout");
            Name = Config.Read("Name");
        }
    }
