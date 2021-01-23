    public class Foo {
        public int Bar { get; set; }
        public int Baz { get; set; }
    }
    dynamic foo = new MyDynamicObject();
    foo.Bar = 5;
    foo.Baz = 6;
    
    Mapper.Initialize(cfg => {});
    
    var result = Mapper.Map<Foo>(foo);
    result.Bar.ShouldEqual(5);
    result.Baz.ShouldEqual(6);
    
    dynamic foo2 = Mapper.Map<MyDynamicObject>(result);
    foo2.Bar.ShouldEqual(5);
    foo2.Baz.ShouldEqual(6);
