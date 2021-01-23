    Public String SKU { get; set; }
    
    Public bool Aattr { get: set; }
    
    Public String SKUwSuffix 
    {
       get
       {
          string sKUwSuffix = SKU; 
          if (Aattr) sKUwSuffix += "-A";
          return sKUwSuffix;
       }
    }
