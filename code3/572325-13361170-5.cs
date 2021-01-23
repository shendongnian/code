    public class Foo1
    {
        public string Field1 { get; set; }
    }
    public class Foo2
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
    }
    Mapper.CreateMap<Foo1, Foo2>();
    var foo1 = new Foo1() {Field1 = "field1"};
    var foo2 = new Foo2();
    Mapper.Map(foo1, foo2);//maps correctly, no Exception
