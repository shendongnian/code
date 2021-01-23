    public MyContext() : base("name=MyContext") 
    { 
        Database.SetInitializer(new MyContextDataInitializer()); 
        this.Configuration.LazyLoadingEnabled = false; 
        this.Configuration.ProxyCreationEnabled = false; 
    } 
