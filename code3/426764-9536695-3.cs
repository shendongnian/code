    private object _backingField;
    public object SomeProperty
    {
      get 
      {
        if(_backingField == null) { _bakcingField = LongOperation(); }
        return _backingField;
      }
      set
      {
        _backingField = value;
      }
    }
