    class Foo : ICloneable {
        public virtual object Clone() { /*...*/ }
    }
    class Bar : Foo {
        public override object Clone() { /*...*/ }
    }
