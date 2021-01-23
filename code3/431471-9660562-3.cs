    public delegate void SomeMethodDelegate();
    public void DoSomething()
    {
        // Do something special
    }
    public void UseDoSomething(SomeMethodDelegate d)
    {
        d();
    }
