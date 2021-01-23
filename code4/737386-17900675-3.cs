    public class Foo
    {
        public string bar; // bar isn't an actual instance of an object, it's just a spot that can hold a string
        
        public void ManipulateBarWithRuntimeError()
        {
            bar.Substring(0, 1); // "bar" isn't actually set to anything, so how can we take a substring of it? This is going to fail at runtime.
        }
    
        public void ManipulateBarWithoutRuntimeError()
        {
            bar = "Hello, world!";
            bar.Substring(0, 1); // bar is actually set to a string object containing some text, so now the Substring method will succeed
        }
        
    }
