    public class SomeClass
    {
        [ExtensionAspect]
        public static IEnumerable<SomeClass> GetOutput(IEnumerable<SomeClass> items)
        {
            return items;
        }
    }
