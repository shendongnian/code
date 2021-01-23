    [DefaultValue(0)]
    private int _myProperty;
    public int MyProperty { 
        get { return _value; }
        set
        {
            if (value !=  _myProperty) {
                 _myProperty = value;
                 HeavyInitialization();
            }
        }
    }
