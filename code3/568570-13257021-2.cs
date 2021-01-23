    public static class ObjectExtensions
    {
        public static bool IsNull(this object obj)
        {
            bool val = false;
            if (obj == null)
            { val = true; }
            return val;
        }
    }
