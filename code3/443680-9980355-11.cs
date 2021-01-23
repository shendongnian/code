    partial class MyClass
    {
        private readonly RegEx matcher;
        public MyClass(string regEx)
        {
            matcher = new RegEx(regEx);
        }
        public bool Match(string value)
        {
            return matcher.IsMatch(value);
        }
    }
