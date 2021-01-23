    abstract class NonGenBase
    {
        public abstract void Foo();
    }
    class GenBase<T>: NonGenBase
    {
        public override void Foo()
        {
            // Do something
        }
    }
