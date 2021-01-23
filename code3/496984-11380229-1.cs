    public class TwoPlusTwoCalculator : ICalculator
    {
        private int _numberOne;
        private int _numberTwo;
        public int NumberOne
        {
            get
            {
                return this._numberOne;
            }
            set
            {
                this._numberOne = value;
            }
        }
        public int NumberTwo
        {
            get
            {
                return this._numberTwo;
            }
            set
            {
                this._numberTwo = value;
            }
        }
        public TwoPlusTwoCalculator ( )
        { }
        public TwoPlusTwoCalculator ( int numOne, int numTwo )
        {
            this.NumberOne = numOne;
            this.NumberTwo = numTwo;
        }
        public int Calculate ( )
        {
            return this.NumberOne + this.NumberTwo;
        }
    }
