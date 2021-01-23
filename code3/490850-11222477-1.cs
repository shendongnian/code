       public class BaseClass
       {
          public double x;
    
          // Constructor:
          public Square(double x) 
          {
             this.x = x;
          }
    
          public virtual double Area() 
          {
             return x*x; 
          }
       }
    
       class InhertingClass1: BaseClass
       {
          // Constructor:
          public Cube(double x): base(x) 
          {
          }
    
          // Calling the Area base method:
          public override double Area() 
          {
             return (6*(base.Area())); 
          }
       }
       class InhertingClass2: BaseClass
       {
          // Constructor:
          public Cube(double x): base(x) 
          {
          }
    
          // Calling the Area base method:
          public override double Area() 
          {
             return (15*(base.Area())); 
          }
       }
