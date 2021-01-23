    public string Method()
    {
        Contract.Requires(Property != null);
        return Property.Trim();
    }
