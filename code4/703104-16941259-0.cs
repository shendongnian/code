     private static int? _min;
     public static int MIN
     {
        set { 
                if (!_min.HasValue())
                {
                    _min = value;
                }
                else
                {
                   throw;
                }
        }
        get {
               return _min.ValueOrDefault();
        }
    
     }
