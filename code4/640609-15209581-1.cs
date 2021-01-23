    class AppleEater : IB<Apple> 
    {  
        public Apple a_val { get; set; }
    }
    class Apple : IA 
    {
        public int val { get; set; }
    }
    class Orange : IA 
    {
        public int val { get; set; }
    }
    ...
    IB<Apple> iba = new AppleEater();
    IB<IA> ibia = iba; // Suppose this were legal. 
    ibia.a_val = new Orange(); // ibia.a_val is of type IA and Orange implements IA
