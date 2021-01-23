    public class Bar
    {
        public Bar(Foo foo)
        {
            foo.SomeEvent += FooEvent;
        }
        public void FooEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Bar.FooEvent!");
        }
    }
    var foo = new Foo();
    var bar = new Bar(foo);
    foo.SomeEvent += (o,e) => Console.WriteLine("SomeEvent");
    Console.WriteLine("Normal");
    foo.Trigger();
