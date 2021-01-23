    string inputString = "Another One Bites The Dust And Another One Down";
    string[] split = inputString.Split();
    foreach (string s in split)
    {
        Console.Write(s.Substring(0,1));
    }
