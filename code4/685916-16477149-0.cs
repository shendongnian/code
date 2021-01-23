    string sURL = "http://subdomain.website.com/index.htm";
    var host = new System.Uri(sURL).Host.ToLower();
    
    string[] col = { ".com", ".cn"/*all needed domain in lower case*/ };
    foreach (string name in col)
    {
        if (host.Contains(name))
        {
            int idx = host.IndexOf(name);
            int sec = host.Substring(0, idx - 1).LastIndexOf('.');
            var rootDomain = host.Substring(sec + 1);
        }
    }
