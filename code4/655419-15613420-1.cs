    public class TestBase
    {
        protected void AreEqual(object obj1, object obj2)
        {
            Assert.AreEqual(obj1, obj2); // etc...
        }
        protected void SuperAssert(bool expression)
        {
            // etc...
        }
    }
