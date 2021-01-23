    public abstract class MathBase
    {
        public double Total { get; protected set; }
        public abstract void DoMath(double val1, double val2);
    }
    public class Add : MathBase
    {
        public override void DoMath(double val1, double val2)
        {
           Total = val1 + val2;
        }
    }
