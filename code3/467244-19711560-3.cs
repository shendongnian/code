    [TestFixture]
    public class MockExtensionsTest
    {
      [TestCase]
      {
        // Setup
        var mock = new Mock<IAmAnInterface>();
        mock.ExpectsInOrder(
          x => x.MyMethod("1"),
          x => x.MyMethod("2"));
        
        // Fake the object being called in order
        mock.Object.MyMethod("1");
        mock.Object.MyMethod("2");
      }
      
      [TestCase]
      {
        // Setup
        var mock = new Mock<IAmAnInterface>();
        mock.ExpectsInOrder(
          x => x.MyMethod("1"),
          x => x.MyMethod("2"));
        
        // Fake the object being called out of order
        Assert.Throws<AssertionException>(() => mock.Object.MyMethod("2"));
      }
    }
    
    public interface IAmAnInterface
    {
      void MyMethod(string param);
    }
