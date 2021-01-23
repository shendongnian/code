    public static class StringExtensions
    {
        public static string TrimToFirst(this string s)
        {
            int index = s.IndexOf('|');
            if(index >= 0)
            {
                s = s.Substring(index + 1);
            }
            return s;
        }
        public static string TrimToLast(this string s)
        {
            int index = s.LastIndexOf('|');
            if(index >= 0)
            {
                s = s.Substring(index + 1);
            }
            return s;
        }
    }
    // usage
    string myString = "violet are blue|roses are red|this is a terrible poet";
    Console.WriteLine(myString.TrimToLast());
    // outpus: this is a terrible poet
