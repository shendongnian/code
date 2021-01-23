        class test
    {
        public StringBuilder get() { return  s; }
        private StringBuilder s = new StringBuilder("World");
    }
    class modifier
    {
        public static void modify(StringBuilder v)
        {
            v.Append("_test");
        }
    }
