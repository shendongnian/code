    public class Foo
    {
        public int Age {get; set;}
    }
    public int GetFooAge(Foo f) { return f.Foo; }
    var source = <some mess'o Foos>;
    source.OrderByDescending(GetFooAge).Dump();
