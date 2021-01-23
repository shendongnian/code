    public class Foo
    {
        public Foo(Action<bool> action)
        {
            // Some existing constructor
        }
    
        public Foo(Action action): this(x => action())
        {
            // Your custom constructor taking an Action and 
            // calling the existing constructor
        }
    }
