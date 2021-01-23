    public abstract class Shape
    {
        public Shape Mutate(int numberOfSides)
        {
            // over simplified example:
            if(numberOfSides == 3)
               return new Triangle();
        }
    }
    
    public class Triangle : Shape {}
    public class Square : Shape {}
