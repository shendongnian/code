    public class MyClass
        {
            public virtual Tuple<int, int> GetQuantities(Entry entry, CartHelper cartHelper)
            {
    
                return new Tuple<int, int>(0, 0);
            }
        }
    
        [TestFixture]
        public class Test
        {
            [Test]
            public void TestMethod()
            {
                var tupleToReturn = Tuple.Create<int, int>(10, 20);
                Mock<MyClass> p = new Mock<MyClass>();
                p.Setup(
               u => u.GetQuantities(It.IsAny<Entry>(),
                       It.IsAny<CartHelper>()))
                          .Returns(tupleToReturn);
    
    
            }
        }
