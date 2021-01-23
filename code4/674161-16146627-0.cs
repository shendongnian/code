    [TestMethod]
    public class YourClassNameTests
    {
      public T YourObject;
      [TestInitialize()]
      public void Initializer()
      {
        YourObject = new T();
      }
      [TestMethod()]
      public void YourMethodTest()
      {
        //Arrange
        YourObject.ReliantProperty = 1;
        //Act
        var objResult = YourObject.YourMethod();
        //Assert
        Assert.IsTrue(objResult == 1);
      }
    }
