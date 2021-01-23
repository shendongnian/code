    [TestFixture]
    public class TestClassTests
    {
         private TestClass _cut;
    
         private Mock<ISystemEvents> _systemEventsMock;         
         private Mock<ITestService> _testServiceMock;
    
         [SetUp]
         public void SetUp()
         {
             _systemEventsMock = new Mock<ISystemEvents>();
             _testServiceMock = new Mock<ITestService>();
    
             _cut = new TestClass(
                _systemEventsMock.Object,
                _testServiceMock.Object
             );
         }
    
         [TestFixture]
         public class OnPowerModeChanged : TestClassTests
         {
             [Test]
             public void When_PowerMode_Resume_Should_Call_TestService_DoStuff()
             {
                 _systemEventsMock.Raise(m => m.PowerModeChanged += null, new PowerModeChangedEventArgs(PowerModes.Resume));
    
                 _testServiceMock.Verify(m => m.DoStuff(), Times.Once);
             }
         }
     }
