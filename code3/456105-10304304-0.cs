    public enum NavigationLinks
    {
        SystemDashboard,
        TradingDashboard,
    }
    public static class Program
    {
        private static string ToFriendlyName(string defaultName)
        {
            var sb = new StringBuilder(defaultName);
            for (int i = 1; i < sb.Length; ++i)
                if (char.IsUpper(sb[i]))
                {
                    sb.Insert(i, ' ');
                    ++i;
                }
            return sb.ToString();
        }
        public static void Main(string[] args)
        {
            var value = NavigationLinks.SystemDashboard;
            var friendlyName = ToFriendlyName(value.ToString());
        }
    }
