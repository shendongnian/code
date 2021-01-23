    class test
    {
        public String MyString
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
            }
        }
        private String s = "World"; 
    }
    class modifier
    {
        public static string modify(String v)
        {
            return v + "_test";
        }
    }
    test c = new test();
    c.MyString = modifier.modify(c.MyString);
