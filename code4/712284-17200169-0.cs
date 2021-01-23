    public ActionResult DoSomething()
    {
        ...
    }
    
    public ActionResult SoSomethingAgain()
    {
        return DoSomething();
    }
