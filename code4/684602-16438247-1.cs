    string inputString = "Another One Bites The Dust";
    string[] split = inputString.split();
    foreach (string s in split)
    {
        Console.Write(s.Substring(0,1));
    }
