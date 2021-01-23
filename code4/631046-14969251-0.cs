    public string Method()
    {
        Contract.Requires(SomeFlag);
        Contract.Assume(Property != null);
        return Property.Trim();
    }
