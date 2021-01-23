    public class Calculator
    {
        protected int ValueOfK()
        {
            return 0;
        }
    }
    
    public class BetterCalculator : Calculator
    {
        protected new int ValueOfK()
        {
            return 1;
        }
    }
