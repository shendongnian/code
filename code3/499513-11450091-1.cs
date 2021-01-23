    interface UnaryFunction
    {
       double Eval(double arg);
    }
    class UnaryOperator:Operator //specializes GetValue
    {
        private UnaryFunction _evaluator; //For Sin this is SinFunction
        //....Rest of the implementatiom
        //....
        public sealed override double GetValue()
        {
            return _evaluator.Eval(_childNode.GetValue());  
        }
    }
    class SinFuntion:UnaryFunction
    {
        public override double Eval(double arg)
        {
            return Math.Sin(arg);          
        }    
    }
