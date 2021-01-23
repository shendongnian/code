    public class ServiceMock : IService
    {
        Mock<IService> _serviceMock;
        public ServiceMock()
        {
            _serviceMock = new Mock<IService>();
            _serviceMock.Setup(x => x.GetString()).Returns("Default String");
    
            SomeClass someClass = new SomeClass();
            someClass.Property1= "Default";
            someClass.Property2= Guid.NewGuid().ToString();
            _serviceMock.Setup(x => x.GetSomeClass()).Returns(someClass);
        }
        public string GetString()
        {
            return _serviceMock.Object.GetString();
        }
        public License GetSomeClass()
        {
            return _serviceMock.Object.GetSomeClass();
        }
    }
