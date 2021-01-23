    public static class Extensions
    {
        public static string D2(this Enum key)
        {
            return Convert.ToInt32(key).ToString("D2");
        }
    }
