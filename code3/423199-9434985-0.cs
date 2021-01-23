    using System;
    using System.Collections.Generic;
    
    public class Test
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, string>(new BadComparer());
            string temp;
            dictionary["bad"] = "oops"; // Fine...
            dictionary.TryGetValue("bad", out temp); // Bang!
        }    
    }
    
    class BadComparer : IEqualityComparer<string>
    {
        public int GetHashCode(string x)
        {
            return x.GetHashCode();
        }
        
        public bool Equals(string x, string y)
        {
            // Bang!
            ((BadComparer) (object) x).ToString();
            return x.Equals(y);
        }
    }
