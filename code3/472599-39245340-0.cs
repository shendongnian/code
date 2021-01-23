       public class TestObject
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
            public string Property3 { get; set; }
        }
        static void Main(string[] args)
        {
            List<TestObject> testObjectList = new List<TestObject>
            {
                new TestObject() { Property1 = "1", Property2 = "2", Property3 = "3" },
                new TestObject() { Property1 = "1", Property2 = "2", Property3 = "3" },
                new TestObject() { Property1 = "1", Property2 = "2", Property3 = "3" }
            };
            List<string[]> convertedTestObjectList = testObjectList.Select(x => new string[] { x.Property1, x.Property2, x.Property3 }).ToList();
        }
    
