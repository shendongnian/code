    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace CollectionAssert
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                IComparer collectionComparer = new CollectionComparer();
                var expected = new List<SomeModel>{ new SomeModel { Name = "SomeOne", Age = 40}, new SomeModel{Name="SomeOther", Age = 50}};
                var actual = new List<SomeModel> { new SomeModel { Name = "SomeOne", Age = 40 }, new SomeModel { Name = "SomeOther", Age = 50 } };
                NUnit.Framework.CollectionAssert.AreEqual(expected, actual, collectionComparer);
            }
        }
        public class SomeModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public class CollectionComparer : IComparer, IComparer<SomeModel>
        {
            public int Compare(SomeModel x, SomeModel y)
            {
                if(x == null || y == null) return -1;
                return x.Age == y.Age && x.Name == y.Name ? 0 : -1;
            }
            public int Compare(object x, object y)
            {
                var modelX = x as SomeModel;
                var modelY = y as SomeModel;
                return Compare(modelX, modelY);
            }
        }
    }
