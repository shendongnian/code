    Class A
    {
      
       propA { get; set; }
       propB { get; set; }
       propC { get; set; }
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
                  //check that propA and propB have values, else return false;
               
               case "apple":
                  //check that propB and propC have values, else throw an exception
           }
       }
    }
