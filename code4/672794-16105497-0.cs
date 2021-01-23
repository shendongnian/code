    private static _field;
    public static MyProperty
    {
        get
        {
             if(_field ==null)
             {
                   _field = defaultValue;
             }
             return _field;
        }
        set
        {
             _field=value;
        }
    }
