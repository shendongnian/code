    var input = new Regex(@"(?<=Version:)\s*(.*)").Matches(@"Name:   My Software
    Version:  1.0.1
    Installed location: c:\my folder")[0].Value.Trim();
    var a = new Version(input);
    var b = new Version("2.0.0");
	
    int comparison = a.CompareTo(b);
	
    if(comparison > 0)
    {
        Console.WriteLine(a + " is a greater version.");
    } 
    else if(comparison == 0)
    {
        Console.WriteLine(a + " and " + b +" are the same version.");
    }	
    else
    {
        Console.WriteLine(b + " is a greater version.");
    }
