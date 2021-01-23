    public class TestCase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class XmlReader
    {
        public static IEnumerable<TestCase> TestCases
        {
        
            get
            {
                // replace this with reading from your xml file and into this array
                return new[]
                           {
                               new TestCase {Id = 1, Name = "A"},
                               new TestCase {Id = 1, Name = "B"}
                           };
            }
        }
    }
    [TestFixture]
    public class TestClass
    {
        [TestCaseSource(typeof(XmlReader), "TestCases")]
        public void SomeTest(TestCase testCase)
        {
            Assert.IsNotNull(testCase);
            Assert.IsNotNull(testCase.Name);
        }
    }
