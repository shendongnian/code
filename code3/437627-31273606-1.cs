    using NSubstitute; /*+ other assemblies*/
    [TestMethod]
    public void Create_should_create_request_and_respond_with_stream()
    {
       //Arrange
       var expected = "response content";
       var expectedBytes = Encoding.UTF8.GetBytes(expected);
       var responseStream = new MemoryStream();
       responseStream.Write(expectedBytes, 0, expectedBytes.Length);
       responseStream.Seek(0, SeekOrigin.Begin);
       var response = Substitute.For<HttpWebResponse>();
       response.GetResponseStream().Returns(responseStream);
       var request = Substitute.For<HttpWebRequest>();
       request.GetResponse().Returns(response);
       var factory = Substitute.For<IHttpWebRequestFactory>();
       factory.Create(Arg.Any<string>()).Returns(request);
       //Act
       var actualRequest = factory.Create("http://www.google.com");
       actualRequest.Method = WebRequestMethods.Http.Get;
       string actual;
       using (var httpWebResponse = (HttpWebResponse)actualRequest.GetResponse())
       {
           using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
           {
               actual = streamReader.ReadToEnd();
           }
       }
       //Assert
       Assert.AreEqual(expected, actual);
    }
    public interface IHttpWebRequestFactory
    {
        HttpWebRequest Create(string uri);
    }
