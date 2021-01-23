    public static class StringExtender
    {
        public static string MyMethod1(this string Input)
        {
            return ...
        }
        public static string MyMethod2(this string Input)
        {
            return ...
        }
    }
    ....
    public string AString = "some string";
    public string NewString = AString.MyMethod1().MyMethod2(); 
