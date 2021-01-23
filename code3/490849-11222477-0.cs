    class TestClass 
    {
       public class Square 
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
    
       class Cube: Square 
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
