    class CBA : IB<A> 
    {  
        public A a_val { get; set; }
    }
    class X : IA 
    {
        public int val { get; set; }
    }
    ...
    IB<A> iba = new CBA();
    IB<IA> ibia = iba; // Suppose this were legal. 
    ibia.a_val = new X(); // ibia.a_val is of type IA and X implements IA
