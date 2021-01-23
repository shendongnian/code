    interface IInterface
    {
        void Method1();
        int Property1 { get; }
    }
    
    abstract class BaseClass: Control, IInterface
    {
        public abstract void Method1();
        public abstract int Property1 { get; }
    }
