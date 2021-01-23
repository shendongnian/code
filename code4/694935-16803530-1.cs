    [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {            
                IEnumerable<int> coll = new int[0];
                IEnumerable coll2 = coll;
             var blah = new Test<IEnumerable<int>>();
        }
    }
    public interface ITest<in T> where T : IEnumerable
    {
    }
    public class Test<T> : ITest<T> where T : IEnumerable { }
  
