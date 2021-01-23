    public class Foo { 
        public virtual void Bar() { ... }
    }
    public class Bar : Foo {
        public override void Bar() { ... }
    }
    // use:
    Foo foo = new Bar(); // make an instance
    foo.Bar(); // calls Bar::Bar
