    public class Base 
    {
        [NegativesAllowed]
        public PositiveNumber Number { get; set; }
    }
    
    public class Derived : Base
    {
        public PositiveNumber Number { get; set; }
    }
