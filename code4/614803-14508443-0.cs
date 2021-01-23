    public static Service1Client MyFoo { get; set; }
    static ServiceLayer()
    {
        MyFoo = new Service1Client();
    }
