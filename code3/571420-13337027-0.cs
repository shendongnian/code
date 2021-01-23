    public class BankTuple
    {
        public BankTuple(int one, int two)
        {
            Checkings = new Checkings(one, two);
            Savings = new Savings(one, two);
        }
    
        public Checkings Checkings { get; private set; }
    
        public Savings Savings { get; private set; }
    }
