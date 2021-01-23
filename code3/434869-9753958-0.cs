    HttpContext ctx = HttpContext.Current;
    Thread t = new Thread((string username) => {
        HttpContext.Current = ctx;
        GetFullName(userName);
    });
    t.IsBackground = true;
    t.Start();
        
    public string GetFullName(string username)
    {
        ProfileBase pb = ProfileBase.Create(username);
        return pb.GetPropertyValue("Name").ToString();
    }
