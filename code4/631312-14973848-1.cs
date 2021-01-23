    public class Control
    {
      public virtual ISet<Property> Properties { get; set; }
    } 
    public abstract class Property
    {
      public virtual string Name { get; set; }
    }
    public class IntProperty : Property
    {
      public virtual int Value { get; set; }
    }
    public class DecimalProperty : Property
    {
      public virtual decimal Value { get; set; }
    }
    // ...
