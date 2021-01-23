    public string MyProperty
    {
        set
        {
            using (new BooleanWrapper(out _dontDoThis))
                Property = value;
        }
    }
