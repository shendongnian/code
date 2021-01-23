    // your property variable
    private const String MyPropertyDefault = "MyValue";
    private String _MyProperty = MyPropertyDefault;
    // your property
    // [DefaultValueAttribute("MyValue")] - cannot use DefaultValue AND ShouldSerialize()/Reset()
    public String MyProperty
    {
        get { return _MyProperty; }
        set { _MyProperty = value; }
    }
    // IMPORTANT!
    // notice that the function name is "ShouldSerialize..." followed
    // by the exact (!) same name as your property
    public Boolean ShouldSerializeMyProperty()
    {
        // here you would normally do your own comparison and return true/false
        // based on whether the property should be serialized, however,
        // in your case, you want to always return true when serializing!
        if (Serializing) // custom control variable that you must implement
            return true;
        else
            return _MyProperty != MyPropertyDefault;
    }
    public void ResetMyProperty()
    {
        _MyProperty = MyPropertyDefault;
    }
