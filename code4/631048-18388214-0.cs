    public string Property
    {
        get {
            Contract.Ensures(Contract.Result<string>() != null);
            return _field ?? String.Empty;
        }
    }
    
