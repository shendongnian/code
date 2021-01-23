    public class Foo<T> : IEnumerable<T>
    {
        // Implementation omitted
        public int CountDistinct()
        {
            return this.Distinct().Count(); // this is required here
        }
    }
