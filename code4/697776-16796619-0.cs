    public class MyModel{
        
        public decimal A {get; set; }
        public decimal B {get; set; }
        public decimal GrandTotal { get { return A + B;}}
    }
