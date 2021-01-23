    public class Operator
    {
        public char TypeChar { get; set; }
    
        public Operator(char operatorType) { this.TypeChar = operatorType; }
    
        public bool IsPositive(int N)
        {
            if (TypeChar != 'N')
               throw new Exception("Cannot call this method for this type of Operator");
    
        // method implementation code
        }
    
        // same for the other methods
    }
    
    public NumericOperator : Operator
    {
        public NumericOperator() : base('N') {}
    }
