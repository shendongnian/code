    [TestClass]
    public class Tests
    {
        private Foo _toTest;
    
        [TestInitialize]
        public void Setup()
        {
            this._toTest = new Foo();       
        }
    
        [TestMethod]
        public void ATest()
        {
            this.Perform_ATest(1, 1, 2);
            this.Setup();
    
            this.Perform_ATest(100, 200, 300);
            this.Setup();
    
            this.Perform_ATest(817001, 212, 817213);
            this.Setup();
                
        }
            
        private void Perform_ATest(int a, int b, int expected)
        {
            //Obviously this would be way more complex...
                
            Assert.IsTrue(this._toTest.Add(a,b) == expected);    
        }
    }
    
    public class Foo
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
