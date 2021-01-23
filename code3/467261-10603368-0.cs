    string c1 = "Accessibility|5102d73a-1b0b-4461-93cd-0c024738c19e";
    string c2 = "5102d73a-1b0b-4461-93cd-0c024738c19e;#5102d73a-1b0b-4461-93cd-0c024733d52d";
    string c3 = "|;#5102d73a-1b0b-4461-93cd-0c024738c19e;#SharePointTag|5102d73a-1b0b-4461-93cd-0c024733d52d";
    string c4 = "Business pages|;#5102d73a-1b0b-4461-93cd-0c024738cz13;#SharePointTag|5102d73a-1b0b-4461-93cd-0c024733d52d";
    string p = @"([a-z0-9]{8}[-][a-z0-9]{4}[-][a-z0-9]{4}[-][a-z0-9]{4}[-][a-z0-9]{12})";
    
    MatchCollection mc;
    
    Console.WriteLine("#1");
    mc = Regex.Matches(c1, p);
    foreach (var id in mc)
    	Console.WriteLine(id);
    
    Console.WriteLine("#2");
    mc = Regex.Matches(c2, p);
    foreach (var id in mc)
    	Console.WriteLine(id);
    
    Console.WriteLine("#3");
    mc = Regex.Matches(c3, p);
    foreach (var id in mc)
    	Console.WriteLine(id);
    
    Console.WriteLine("#4");
    mc = Regex.Matches(c4, p);
    foreach (var id in mc)
    	Console.WriteLine(id);
