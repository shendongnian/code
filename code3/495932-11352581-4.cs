    string vars = proxy.Split(':'.ToCharArray());
    if (vars.Length == 2) 
    {
        string MyProxyHostString = vars[0];
        int MyProxyPort = int.Parse(vars[1]); // Better if you use int.TryParse method
    }
