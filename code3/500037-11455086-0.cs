    public class foo
    {
        public foo(string a, string b) { }
    }
    public class bar : foo
    {
        public bar()
            : base("apple", "banana")
        {
        }
    }
