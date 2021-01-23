    string s = "        qsdmlkqmlsdkm";
    Console.WriteLine(s.TrimStart());
    Console.WriteLine(s.Length - s.TrimStart().Length);
    Console.WriteLine(s.FirstOrDefault(c => !Char.IsWhiteSpace(c)));
    Console.WriteLine(s.IndexOf(s.FirstOrDefault(c => !Char.IsWhiteSpace(c))));
