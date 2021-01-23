    Regex r=new Regex(@"(public|private).*?(?=(public|private|$))",RegexOptions.Singleline);
    Regex nr=new Regex(@"\(.*?\)\s+\{",RegexOptions.Singleline);
    foreach(Match m in r.Matches(yourString))//extracts all methods and properties
    {
    if(!nr.IsMatch(m.Value))//shoots down methods
    m.Value;//properties only
    }
