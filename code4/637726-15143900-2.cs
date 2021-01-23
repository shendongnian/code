    public class A
    {
        public string Name { get; set; }
        public B Link1 { get; set; }
    }
    public class B
    {
        public string Name { get; set; }
        public A Link2 { get; set; }
    }
    var dto = new A { 
       Name = "A1", 
       Link1 = new B { Name = "B1", Link2 = new A { Name = "A2" } } 
    };
    dto.ToJson().Print();
