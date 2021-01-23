    public class A : IA
    {
        public int fooA { get; set; }
        public void methodA(int value) { fooA = value; }
    }
    public class B : IB
    {
        public int fooB { get; set; }
        public void methodB(int value) { fooB = value; }
    }
