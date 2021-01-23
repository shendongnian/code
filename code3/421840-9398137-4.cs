    class AddingCalculator : Calculator
    {
        public AddingCalculator(int num1, int num2)
            : base(num1, num2)
        {
        }
        public override int Calculate()
        {
            return _num1 + _num2;
        }
    }
    class SubtractingCalculator : Calculator
    {
        public SubtractingCalculator(int num1, int num2)
            : base(num1, num2)
        {
        }
        public override int Calculate()
        {
            return _num1 - _num2;
        }
    }
