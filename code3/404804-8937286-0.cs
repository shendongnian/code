    public interface IA
    {
        void Foo();
        //void Bar(); - removed
    }
    public abstract class A : IA
    {
        virtual void Foo()
        { }
        // Removed method
        //virtual void Bar()
        //{ }
    }
    public class B : A
    {
        public override void Foo()
        { }
        //throws an error like the one you were receiving regarding no method to override.
        public override void Bar()
        { }
    }
