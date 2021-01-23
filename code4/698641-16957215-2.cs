    [TestMethod]
    public void FreezeByName_Sets_Value1_And_Value2_Independently()
    {
        //// Arrange
        IFixture arrangeFixture = new Fixture();
        string myValue1 = arrangeFixture.Create<string>();
        string myValue2 = arrangeFixture.Create<string>();
        
        IFixture sutFixture = new Fixture();
        sutFixture.FreezeByName("value1", myValue1);
        sutFixture.FreezeByName("value2", myValue2);
        
        //// Act
        TestClass<string> result = sutFixture.Create<TestClass<string>>();
        //// Assert
        Assert.AreEqual(myValue1, result.Value1);
        Assert.AreEqual(myValue2, result.Value2);
    }
    public class TestClass<T>
    {
        public TestClass(T value1, T value2)
        {
            this.Value1 = value1;
            this.Value2 = value2;
        }
        public T Value1 { get; private set; }
        public T Value2 { get; private set; }
    }
