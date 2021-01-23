    public class Base
    {
      public virtual string Name {get; set;}
    }
    
    public class Derived : Base
    {
      private string _name;
    
      public override string Name 
      {
        get { 
          return _name; 
        }
        set 
        { 
          //access the base property we are overriding
          base.Name = value + " from derived";
          _name = value;
        }
      }
    }
