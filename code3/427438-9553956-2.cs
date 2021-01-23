    class MyClass
    {
        private static string[] bar;
        public static string[] Bar
        {
            get { return bar; }
            set
            {
                if (bar == null)
                    bar = value;
            }
        }
    }
