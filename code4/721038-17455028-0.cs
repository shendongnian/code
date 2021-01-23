    string s = "hello";
    string original = s;
    Console.WriteLine(ReferenceEquals(s, original)); // True
    s = s + "User";
    Console.WriteLine(ReferenceEquals(s, original)); // False
