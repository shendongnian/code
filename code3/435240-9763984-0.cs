    string s1 = "t";
    string s2 = 't'.ToString();        
    Console.WriteLine(s1.Equals(s2)); // true because both reference equality (interned strings) and value equality (string overrides Equals())
    Console.WriteLine(object.Equals(s1, s2)); // true because of reference equality (interned strings)
    StringBuilder s1 = new StringBuilder();
    StringBuilder s2 = new StringBuilder();
    Console.WriteLine(s1.Equals(s2)); // true because StringBuilder.Equals() overridden
    Console.WriteLine(object.Equals(s1, s2)); // false because the two StringBuilder instances have different addresses (references not equal)
