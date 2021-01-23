    abstract class UnaryOperator:Operator //specializes GetValue
    {
        //....Rest of the implementatiom
        //....
        public sealed override double GetValue()
        {
            return Eval(_childNode.GetValue());  
        }
        protected abstract double Operate(double arg);
    }
    class SinOperator:UnaryOperator
    {
        public override double Eval(double arg)
        {
            return Math.Sin(arg);          
        }    
    }
