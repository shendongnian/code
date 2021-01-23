    private SomeType privateVar1;
    public SomeType PublicVar1
    {
        get { return privateVar1; }
        set
        {
            SetAndNotify(ref privateVar1, value, () => PublicVar1);
            MyOtherPublicVar = someNewValue; // this will activate the property's setter.       
        }
    }
