    public abstract class Foo
    {
        public virtual void Access(Foo foo)
        {
            // perform the default implementation here, but mark as virtual to enable a child class to override it.
        }
    }
    public class Bar : Foo
    {
        public override void Access(Foo foo)
        {
            var bar = foo as Bar;
            if (bar != null)
            {
                // If you get here, that means foo is a Bar.
                // Just use bar now and ignore foo.
            }
            else
            {
                // Fall back on the base classes implementation
                base.Access(foo);
            }
        }
    }
