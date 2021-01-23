    string[] inputs = 
    {
        "Master Language=\"C#\" MasterPageFile=\"~/masterpages/Libraries.master\"", // true
        "Language=\"C#\" MasterPageFile=\"~/masterpages/Libraries.master\" Master", // true
        "Language=\"C#\" MasterPageFile=\"~/masterpages/Libraries.master\"" // false
    };
    
    string pattern = @"^(?=.*\bMaster\b)(?=.*Language=""C#"").+$";
    
    foreach (var input in inputs)
    {
        Console.WriteLine(Regex.IsMatch(input, pattern));
    }
