    public abstract class Base
    {
        protected static double Calculate(Base b) 
        { 
            // perfectly legal inside Base:
            return b.Calculate(); 
        }        
        protected abstract double Calculate();
    }
    public class Derived : Base
    {
        private Base b;
        protected override double Calculate()
        {
            double r = B.Calculate(b);
            // Perform additional calculations on r
            return r;
        }
    }
