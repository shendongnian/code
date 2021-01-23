    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<SomeType>
                {
                    new SomeType("Mr", "Joe", "Bloggs"),
                    new SomeType("Mr", "John", "Citizen"),
                    new SomeType("Mrs", "Mary", "Mac")
                };
            var list2 = list.GroupBy(by => new { by.Property1, by.Property2 });
        }
    }
    public class SomeType
    {
        public string Property1 { get; private set; }
        public string Property2 { get; private set; }
        public string Property3 { get; private set; }
        public SomeType(string property1, string property2, string property3)
        {
            Property1 = property1;
            Property2 = property2;
            Property3 = property3;
        }
    }
