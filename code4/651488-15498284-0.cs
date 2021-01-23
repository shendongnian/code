    public IHelper Helper { private get; set; }
    ...    
    public ActionResult SomeAction()
    {
        var hepler = new Helper();
        helper.DoStuff();
        ...
    }
