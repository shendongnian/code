    public class IntProblem : IProblem<int>
    {
        private int _number1 { get; set; }
        private int _number2 { get; set; }
    
        public int Response { get; set; }
    
        public IntProblem(int number1, int number2)
        {
            this._number1 = number1;
            this._number2 = number2;
        }
    
        public bool IsCorrect()
        {
            return this._number1 + this._number2 == Response;
        }
    }
    
    public class DecimalProblem : IProblem<decimal>
    {
        private decimal _number1 { get; set; }
        private decimal _number2 { get; set; }
    
        public decimal Response { get; set; }
    
        public DecimalProblem(decimal number1, decimal number2)
        {
            this._number1 = number1;
            this._number2 = number2;
        }
    
        public bool IsCorrect()
        {
            return this._number1 / this._number2 == Response;
        }
    }
