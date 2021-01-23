    [TestClass]
    public class MyTestClass{
    
    private IService _service;
    
    [TestInitialize]
    public void Setup(){
    _service = MockRepository.GenerateStrictMock<IService, ICommunicationObject>();
    }
    
    [TestMethod]
    public void TestWhatsGoingOn(){
    
    _service.Expect(.....).Return(.....);
    
    //This will test the close is called too (hence the ICommunicationObject above)
    ((ICommunicationObject)_service).Expect(r => r.Close());
    }
    
    [TestCleanup]
    public void CleanItUp{
    _service.VerifyAllExpectations();
    }
