    public static class StringExtensions
    {
        public static string AppendIf(this string s, bool condition, string append)
        {            
           return condition ? s + append : s;
        }
    }
    string x = "Foo";
    x.AppendIf(someTest, "bar");
    // or even
    string y = "Foo".AppendIf(someTest, "bar");
