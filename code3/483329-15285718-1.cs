            [Test]
        public void NewwebrequestCreatesWebRequest()
        {
            var mockCreate = new Mock<IWebRequestCreate>();
            mockCreate.Setup(x => x.Create(It.IsAny<Uri>()));
            HTTPRequestFactory webrequest = new HTTPRequestFactory(mockCreate.Object);
            HttpWebRequest request = (HttpWebRequest)webrequest.Create(testURI);
            mockCreate.VerifyAll();       
        }
        [Test]
        public void webrequestUsesAddressProperty()
        {
            var mockCreate = new Mock<IWebRequestCreate>();
            string IP = "10.99.99.99";
            Uri expected = new Uri("http://10.99.99.99/services");
            mockCreate.Setup(x => x.Create(expected));
            HTTPRequestFactory webrequest = new HTTPRequestFactory(mockCreate.Object);
            webrequest.address = IP;
            HttpWebRequest request = (HttpWebRequest)webrequest.Create(testURI);
            mockCreate.VerifyAll();
        }
