    private static List<string> _ListToWatch;
    public static List<string> ListToWatch
    {
        get
            {
             if(_ListToWatch == null) 
                  _ListToWatch = new List();
              return _ListToWatch;
             }
        set 
         {
          _ListToWatch = value;
         }
    
    }
