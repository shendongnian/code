    public static class ObjectExtensions
    {
        public static string SafeToString(this object o)
        {
            if (o != null)
            {
                return o.ToString();
            }
            return "";
        } 
    }
