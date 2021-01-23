    interface IMath
    {
        string DoMath();
    }
    abstract class MathBase : IMath
    {
        protected double Total { get; set; }
        public abstract string DoMath();
    }
    class Add : MathBase
    {
        public override string DoMath()
        {
            this.Total = 2;
            return "2";
        }
    }
