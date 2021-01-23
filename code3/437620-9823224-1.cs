    var yourMockedResponseStream = new MemoryStream();
    // etc.
    
    
    var response = new Mock<HttpWebResponse>();
    response.Setup(c => c.GetResponseStream()).Returns(yourMockedResponseStream);
    
    var request = new Mock<HttpWebRequest>();
    request.Setup(c => c.GetResponse()).Returns(response.Object);
    
    var factory = new Mock<IHttpWebRequestFactory>();
    factory.Setup(c => c.Create(It.IsAny<string>()).Returns(request.Object);
