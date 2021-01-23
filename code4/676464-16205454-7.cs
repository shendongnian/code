    public static class Extensions
    {
        public static Boolean ToBoolean(this string str)
        {
            try
            {
                return Convert.ToBoolean(str);
            }
            catch { }
            try
            {
                return Convert.ToBoolean(Convert.ToInt32(str));
            }
            catch { }
            return false;
        }
    }
