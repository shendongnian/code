    Regex r = new Regex(@"\Gd");
    string s = "abcdefg";
    Console.WriteLine(r.Match(s, 1).Success); // False
    Console.WriteLine(r.Match(s, 3).Success); // True
    Console.WriteLine(r.Match(s, 5).Success); // False
