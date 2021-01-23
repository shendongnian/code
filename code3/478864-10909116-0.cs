    public class Base
    {
      public Base(double d1, double d2)
      {
      }
    }
    
    public Eclipse : Base
    {
       public Ellipse(double diameter)
            : base(diameter, diameter)
       {
       }
    }
