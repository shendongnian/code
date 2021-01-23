    [TestFixture]
    public class BaseTestsClass
    {
        //some public/protected fields to be set in SetUp and OnSetUp
        [SetUp]
        public void SetUp()
        {
            //basic SetUp method
            OnSetUp();
        }
        public virtual void OnSetUp()
        {
        }
        [Test]
        public void SomeTestCase()
        {
            //...
        }
        [Test]
        public void SomeOtherTestCase()
        {
            //...
        }
    }
    [TestFixture]
    public class TestClassWithSpecificSetUp : BaseTestsClass
    {
        public virtual void OnSetUp()
        {
            //setup some fields
        }
    }
    [TestFixture]
    public class OtherTestClassWithSpecificSetUp : BaseTestsClass
    {
        public virtual void OnSetUp()
        {
            //setup some fields
        }
    }
