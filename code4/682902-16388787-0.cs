    private List<UserValues> _Values = [whatever];
    private ReadOnlyCollection<UserValues> _ValuesWrapper = _Values.AsReadOnly();
    public ReadOnlyCollection<UserValues> Values
    {
      get { return _ValuesWrapper; }
    }
