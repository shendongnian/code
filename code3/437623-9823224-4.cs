    [Test]
    public void Create_should_create_request_and_respond_with_stream()
    {
        // arrange
        var expected = "response content";
        var expectedBytes = Encoding.UTF8.GetBytes(expected);
        var responseStream = new MemoryStream();
        responseStream.Write(expectedBytes, 0, expectedBytes.Length);
        responseStream.Seek(0, SeekOrigin.Begin);
        var response = new Mock<HttpWebResponse>();
        response.Setup(c => c.GetResponseStream()).Returns(responseStream);
        var request = new Mock<HttpWebRequest>();
        request.Setup(c => c.GetResponse()).Returns(response.Object);
        var factory = new Mock<IHttpWebRequestFactory>();
        factory.Setup(c => c.Create(It.IsAny<string>()))
            .Returns(request.Object);
        // act
        var actualRequest = factory.Object.Create("http://www.google.com");
        actualRequest.Method = WebRequestMethods.Http.Get;
        string actual;
        using (var httpWebResponse = (HttpWebResponse)actualRequest.GetResponse())
        {
            using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                actual = streamReader.ReadToEnd();
            }
        }
        // assert
        actual.Should().Be(expected);
    }
    public interface IHttpWebRequestFactory
    {
        HttpWebRequest Create(string uri);
    }
