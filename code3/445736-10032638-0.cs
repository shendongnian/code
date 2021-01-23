    [TestMethod]
    public void TestMethod2()
    {
        // Arrange
        var po = new PrivateObject(typeof(MyObject));
        var obj = (MyObject)po.Target;
        // Act
        var result = obj.Calculate(2);
        // Assert
        Assert.AreEqual(3, resul);
    }
    public class MyObject
    {
        internal MyObject()
        {
        }
 
        public int Calculate(int a)
        {
            return 1 + a;
        }
    }
