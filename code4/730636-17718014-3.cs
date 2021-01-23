    class Foo
    {
        public MyClass Bar {get; set;}
        public int Baz {get; set;}
    }
    var FooList = new List<Foo>();
    MyClass sumOfFooListsBars = FooList.Sum(f => f.Bar);
