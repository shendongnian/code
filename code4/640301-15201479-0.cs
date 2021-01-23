    public void GetPopulatedValues(A instance)
    {
        instance.Prop1 = (whatever);
    }
    public void Init()
    {
        var obj = new B();
        GetPopulatedValues(obj);
    }
