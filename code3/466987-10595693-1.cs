    public string _abc;
    public string abc 
    { 
      get
      {        
        return _abc;
      };
 
      set
      {
        if (value == null)
          _abc = "";
        else
          _abc = value;
      }; 
    }
