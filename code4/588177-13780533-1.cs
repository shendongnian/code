    [TestFixture]
        public class TestingOurCalls()
        {
            [Test]
            public Void TestTheProductCall()  
            {    
            var webServiceProxy = MockRepository.GenerateMock<IWebServiceProxy>();
            SomeClass someClass = new SomeClass(webServiceProxy);
            webServiceProxy.Expect(p=>p.Post("/MyService/Product"));
            someClass.PostTheProduct(Arg<string>.Is.Anything());
            webServiceProxy.VerifyAllExpectations();
           }
 }
