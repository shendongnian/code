    namespace MyProject 
    {
        public class PublicClass 
        {
            public UtilClass DoSomething() {} 
            public UtilClass { get; }
            // External assemblies cannot see the UtilClass  type which is
            // why this does not work.
        }
    }
