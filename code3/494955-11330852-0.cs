    public delegate void DoWorkDelegate(CustomWorkParameters p);
    public DoWorkDelegate DoWorkCallback
    {
      get
      {
        return _workCallback;
      }
      set 
      {
        _workCallback = value;
      }
    }
