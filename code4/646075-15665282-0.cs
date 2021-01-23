    // your property variable
    private String _MyProperty = "MyValue";
    // your property
    [DefaultValueAttribute("MyValue")]
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
        // in your case, you want to always return true.
        return true;
    }
