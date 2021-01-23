    string s1 = "john";
    object s2 = "john";
    string s3 = new StringBuilder(s1).ToString();
    Console.WriteLine(s1 == s2); // True
    Console.WriteLine(s2 == s1); // True
    Console.WriteLine(s1 == s3); // True
    Console.WriteLine(s2 == s3); // False
    Console.WriteLine(s3 == s2); // False
    Console.WriteLine(s3 == s1); // True
