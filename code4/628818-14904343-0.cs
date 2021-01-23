    class Project : ICloneable
    {
       //rest of your class
       int blah;
       string blah2;
 
       public Project()
       {
          
       }
       //rest of your class
 
       public object Clone()
       {
          return this.MemberwiseClone();      // call clone method
       }
    }
