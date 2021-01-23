        [Test]
        public void MyTest()
        {
            var mockRequestContext = new Mock<IRequestContext>();
            var mockedHttpRequest = new Mock<IHttpRequest>();
            NameValueCollection querystring = new NameValueCollection();
            querystring.Add("myKey", "myValue");
            mockedHttpRequest.SetupGet(r => r.QueryString).Returns(querystring);
            mockRequestContext.Setup(x => x.Get<IHttpRequest>()).Returns(mockedHttpRequest.Object);
            AboutService service = new AboutService
            {
                RequestContext  = mockRequestContext.Object,
            };
            AboutResponse response = (AboutResponse)service.Any(new About
            {
                Company = "myOtherValue",
            });
            Assert.AreEqual(0, response.QueryResult);
            Assert.AreEqual("validResponse", response.Version);
        }
