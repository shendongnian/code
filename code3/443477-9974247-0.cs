    [TestClass]
    public class FooTests
    {
       private Foo _foo;
       private Mock<IWcfClientProxy<ITestingServiceInterface>> _clientProxy;
    
       [TestInitialize]
       public void SettingUp()
       {
           _clientProxy = new Mock<IWcfClientProxy<ITestingServiceInterface>>();
           _foo = new Foo(_clientProxy.Object);
       }
    
       [TestMethod]
       public void SimpleTest()
       {
           // Act on object being tested
           _foo.Bar(5);
           // verify it executed correct method on dependency
           _clientProxy.Verify(cp => cp.Execute(x => x.DoSomeDelete(5)));
        }
    }
