    private int mMyIntProperty = 0;
    public string MyIntProperty
    {
        get { return mMyIntProperty; }
        set { SetProperty("MyIntProperty", ref mMyIntProperty, value); }
    }
