    [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {            
                IEnumerable<int> coll = new int[0];
                IEnumerable coll2 = coll;
                var blah = new test<IEnumerable<int>>();
            }
        }
        class test<T> where T : IEnumerable
        {
        }
  
