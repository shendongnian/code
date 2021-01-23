    Public String SKU { get; set; }
    
    Public bool Aattr { get: set; }
    Public bool Battr { get: set; }
    Public bool Cattr { get: set; }
    
    Public String SKUwSuffix 
    {
       get
       {
          string sKUwSuffix = SKU; 
          if (Aattr) sKUwSuffix += "-A";
          if (Battr) sKUwSuffix += "-B";
          if (Cattr) sKUwSuffix += "-C";
          return sKUwSuffix;
       }
    }
