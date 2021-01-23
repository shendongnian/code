    public interface ISomeInterface { ... }
    public class SomeClass : ISomeInterface
    { 
        public static readonly SomeClass Instance = new SomeClass();
        private SomeClass()
        { 
        }
        // Implement ISomeInterface here
    }
