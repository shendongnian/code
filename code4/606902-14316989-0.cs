    public class Foo {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    // in controller:
    public ActionResult Bar(Foo myFoo) {
        // do stuff with Foo
    }
