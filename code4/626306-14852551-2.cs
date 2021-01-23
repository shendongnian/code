    public void DoSomething()
    {
        this.DoSomethingWith(this)
    }
    public void DoSomethingWith(INode it)
    {
        // ...
        var someInstance = someFactory.Create(it);
        // ...
    }
