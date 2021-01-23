    public static class StringExtensions
    {
        public static bool Contains(this string s, params string[] predicates)
        {
            return predicates.All(s.Contains);
        }
    }
    string d = "You hit someone for 50 damage";
    string a = "damage";
    string b = "someone";
    string c = "you";
    
    if (d.Contains(a, b))
    {
        Console.WriteLine("d contains a and b");
    }
