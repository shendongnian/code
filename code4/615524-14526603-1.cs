    string pattern = @"^(Help)\s#\s[0-9]{3,5}";
    Regex regex = new Regex(pattern);
    foreach (string s in list)
    {
        if (regex.Match(s).Success) 
            Console.WriteLine(s);
    }
    Console.WriteLine("Done.");
    Console.ReadKey();
        
