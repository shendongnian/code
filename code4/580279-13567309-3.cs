    public interface ISomeInterface { ... }
    public class SomeClass : ISomeInterface
    { 
        public static readonly ISomeInterface Instance = new SomeClass();
        // or
        public static readonly SomeClass Instance = new SomeClass();
        private SomeClass()
        { // Allow only one instance }
        // Implement ISomeInterface here
    }
