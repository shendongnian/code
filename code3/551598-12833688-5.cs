    public class A 
    {
        public string MyPropertyA1 { get; set; }
        public int MyPropertyA2 { get; set; }
    }
    public class B 
    {
        public int MyPropertyB1 { get; set; }
        public int MyPropertyB2 { get; set; }
    }
    
    public class C
    {
        public int MyPropertyC1 { get; set; }
        public A MyPropertyA { get; set; }
        public B MyPropertyB { get; set; }
        public C()
        {
           MyPropertyA = new A() { MyPropertyA1 = "TestValue" };
        }
    }
