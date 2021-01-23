    public double ValueA
    {
      get { return _valueA; }
      set 
      {
        _valueA = value;
        OnPropertyChanged("ValueA");
      }
    }
