    string x = "hello";
    string y = new StringBuilder("h").Append("ello").ToString();
    Console.WriteLine(x == y); // True (overloaded ==)
    Console.WriteLine(x.GetHashCode() == y.GetHashCode()); // True (overridden)
   
    IdentityComparer<string> comparer = new IdentityComparer<string>();
    Console.WriteLine(comparer.Equals(x, y)); // False - not identity
    // Very probably false; not absolutely guaranteed (as ever, collisions
    // are possible)
    Console.WriteLine(comparer.GetHashCode(x) == comparer.GetHashCode(y));
