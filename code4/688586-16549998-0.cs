    public void func(string s)
    {
        s = Regex.Replace(s, @"(\r\n|\n\r|\n|\r)", "\r\n");
        Regex r = new Regex("^\s*Pattern\s*$", RegexOptions.Multiline | RegexOptions.ExplicitCapture );
        Match m = r.Match(s);
        //Do something with m
    }
