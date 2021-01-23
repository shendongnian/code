    public abstract class MathBase
    {
        public double Total { get; protected set; }
        public abstract string DoMath(double val1, double val2);
    }
    public class Add : MathBase
    {
        public override string DoMath(double val1, double val2)
        {
           Total = val1 + val2;
           return Convert.ToString(Total);
        }
    }
