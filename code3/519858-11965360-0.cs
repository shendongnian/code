    class A {
        public dynamic property1 { get; set; }
        public dynamic property2 { get; set; }
    }
    class Program {
        
        static void Main(string[] args) {
            A a = new A();
            A b = new A();
            a.property1 = "hello world!";
            b.property2 = a.property1;
            Console.WriteLine(b.property2); // writes "hello world!"
        }
    }
