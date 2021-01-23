    public void TestX()
    {
        //X is of type X
        var x = new X();
        UseIX(x);
    }
    public void UseIX(IX interfaceParam)
    {
        interfaceParam.Foo = 1;
    }
