    [TestFixture]
    public class MyTests
    {
        private ServiceHost service;
    
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            service = new ServiceHost(typeof(MyService));
            service.Open();
        }
    
        [Test]
        public void ThisIsATest()
        {
            service.DoStuff(); // test whatever
        }
    
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            if (service != null)
            {
                if (service.State == CommunicationState.Opened)
                    service.Close();
                else if (service.State == CommunicationState.Faulted)
                    service.Abort();
            }
        }
    }
