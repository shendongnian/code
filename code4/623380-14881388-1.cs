     [TestClass]
        public class ChunkyListTests
        {
            [TestMethod]
             public void GetEnumerator_NoItems()
             {
                 var chunkyList = new ChunkyList<float>();
    
                 var wasInsideForeach = false;
                 foreach (var item in chunkyList)
                     wasInsideForeach = true;
    
                 Assert.IsFalse(wasInsideForeach);
             }
    
            [TestMethod]
            public void GetEnumerator_MaxBlockSizeOfThreeWithThreeItems()
            {
                var chunkyList = new ChunkyList<float> (3) { 1, 2, 3 };
    
                var wasInsideForeach = false;
                var iteratedItems = new List<float>();
                foreach (var item in chunkyList)
                {
                    wasInsideForeach = true;
                    iteratedItems.Add(item);
                }
    
                Assert.IsTrue(wasInsideForeach);
                CollectionAssert.AreEqual(new List<float> { 1, 2, 3 }, iteratedItems);
            }
    
            [TestMethod]
            public void GetEnumerator_MaxBlockSizeOfTwoWithThreeItems()
            {
                var chunkyList = new ChunkyList<float>(2) {1,2,3};
                var wasInsideForeach = false;
                var iteratedItems = new List<float>();
    
                foreach (var item in chunkyList)
                {
                    wasInsideForeach = true;
                    iteratedItems.Add(item);
                }
    
                Assert.IsTrue(wasInsideForeach);
                CollectionAssert.AreEqual(new List<float>() { 1, 2, 3 }, iteratedItems);
                Assert.AreEqual(chunkyList.MaxBlockSize, 2);
            }
        }
