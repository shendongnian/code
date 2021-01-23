    HttpContext ctx = ThreadingFixHttpContext();
    Thread newThread = new System.Threading.Thread(new ThreadStart(() =>
    {
        HttpContext.Current = ctx;
        Thread.CurrentPrincipal = ctx.User;
        var test = HttpContext.Current.Session["testKey"];
    }));
    newThread.Start();
