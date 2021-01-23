    public YourClass
    {
    
       string oldValue;
       string newValue;
       public string NewValue
       { get { return newValue; }
         set { if( ! value.Equals( newValue ))
               {
                  oldValue = newValue; 
                  newValue = value; 
               }
             }
       }
    
    }
