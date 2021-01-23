    public int MyProperty
    {
      get
      {
        // Your own logic, like lazy loading
        return _myProperty ?? (_myProperty = GetMyProperty());
      }
    }
