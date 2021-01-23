    [TestFixture]
    public class TestClass
    {
            [Test]
            public override void AssertThrowsNullReferenceOrInvalidOperation()
            {
                tempFunction = Controller.TestMethod;
                base.AssertThrowsNullReferenceOrInvalidOperation();
            }
    }
