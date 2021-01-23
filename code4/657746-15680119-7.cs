    public abstract class MathBase
    {
        public double Total { get; protected set; }
        public abstract string DoMath(double value);
        protected double ParseValue(string value)
        {
            double parsedValue;
            if (!double.TryParse(value, out parsedValue))
            {
                throw new ArgumentException(string.Format("The value '{0}' is not a number.", value), "value");
            }
            return parsedValue;
        }
    }
    public class Add : MathBase
    {
        public override string DoMath(string value)
        {
            Total += ParseValue(value);
            return Convert.ToString(Total);
        }
    }
