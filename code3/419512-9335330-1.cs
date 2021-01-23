    if (ConfigurationManager.AppSettings["Mode"] == "Dev")
    {
        Database.SetInitializer<PonosContext>(new PonosInitializer());
        new MyContext().Database.Initialize(true);
    }
