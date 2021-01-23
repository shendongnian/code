    public class TestClass
    {
        private MyContext context;
        [SetUp]
        public void Setup()
        {
            // is executed before each test
            context = new MyContext();
        }
        [Test]
        public void Test1()
        
            context.SomeTable.ToList().Where(s => s.Id <= 10);
        }
        [TearDown]
        public void Complete()
        {
            context.Dispose();
        }
    }
