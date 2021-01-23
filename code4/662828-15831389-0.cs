    string[] strTobeValidate = new string[] {"333TEST", "TEST4444-1234-AB", "ABCD12AB-1234-99", "ABCD2345-1234-AB", "PPP12AA-9876" };
    Regex r = new Regex(@"[A-Za-z]{4}[A-Za-z0-9]{4}-[0-9]{4}-[A-Za-z]{2}");
    foreach(string s in strTobeValidate)
    {
        Match m = r.Match(s);
        if(m.Success == false)
            Console.WriteLine("Not found");
        else
            Console.WriteLine(m.ToString());
        
    }
