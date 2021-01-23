    public static class ObjectExtensions
    {
        public static int ToInt32(this object obj)
        {
            return 42;
        }
    }
    // (...)
    object o = new object();
    int i = o.ToInt32();
