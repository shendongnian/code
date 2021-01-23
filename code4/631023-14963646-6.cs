    private string Method()
    {
        SetField();
        Contract.Assume(Property != null);
        return Property.Trim();
    }
