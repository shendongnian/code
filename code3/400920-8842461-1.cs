    private SomeType _myProperty;
    public SomeType MyProperty
    {
        get
        {
            if (_myProperty == null) {
                _myProperty = new SomeType();
            }
            return _myProperty;
        }
    }
