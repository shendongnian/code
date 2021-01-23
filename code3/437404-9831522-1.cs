    Class A
    {
       Nullable<int> propA { get; set; }
       int? propB { get; set; }
       int? propC { get; set; }
       string target { 
          get { return _target; } 
          set { 
             var oldtarget = _target;
             _target = value; 
             if !IsValid() 
             {
                 _target = oldtarget;
                 throw new Exception("Setting target to " 
                            + value 
                            + " is not possible, ....");
             }
          } 
       }
       public bool IsValid()
       {
           switch (_target)
           {
               case "banana":
                  return propA.HasValue() && propB.HasValue();
               
               case "apple":
                  return propB.HasValue() && propC.HasValue();
           }
          
           return true;
       }
    }
