    public class Foo
    {
        public string Bar { get; set; }
    }
    public void SomeStrangeMethod()
    {
        Foo foo = new Foo() { Bar = "Hello" };
        string result = foo.FindContext(s => s.Bar);  // should return "Bar"
    }
