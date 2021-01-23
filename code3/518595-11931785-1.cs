    abstract class Property {
        public abstract void SomeMethod();
    }
    class Property<T> : Property {
        public override void SomeMethod() {...}
    }
