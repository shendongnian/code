    class Z
    {
    protected virtual AfterMethodCalled(){}
    
    public void Method()
    {
    //do its job
    AfterMethodCalled();
    }
    }
    
    classA:Z
    {
    protected override AfterMethodCalled()
    {
    //do its job 
    }
    }
