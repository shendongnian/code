        using Moq;
        using Moq.Protected;
        using NUnit.Framework;
    namespace Unit.Tests
    {
        [TestFixture]
        public sealed class Tests1
        {
            private HttpClient _client;
            private HttpRequestMessage _httpRequest;
            private Mock<DelegatingHandler> _testHandler;
    
            private MyCustomHandler _subject;//MyCustomHandler inherits DelegatingHandler
    
            [SetUp]
            public void Setup()
            {
                _httpRequest = new HttpRequestMessage(HttpMethod.Get, "/someurl");
                _testHandler = new Mock<DelegatingHandler>();
    
                _subject = new MyCustomHandler // create subject
                {
                    InnerHandler = _testHandler.Object //initialize InnerHandler with our mock
                };
    
                _client = new HttpClient(_subject)
                {
                    BaseAddress = new Uri("http://localhost")
                };
            }
    
            [Test]
            public async Task Given_1()
            {
                var mockedResult = new HttpResponseMessage(HttpStatusCode.Accepted);
    
                void AssertThatRequestCorrect(HttpRequestMessage request, CancellationToken token)
                {
                    Assert.That(request, Is.SameAs(_httpRequest));
                    //... Other asserts
                }
    
                // setup protected SendAsync 
                // our MyCustomHandler will call SendAsync internally, and we want to check this call
                _testHandler
                    .Protected()
                    .Setup<Task<HttpResponseMessage>>("SendAsync", _httpRequest, ItExpr.IsAny<CancellationToken>())
                    .Callback(
                        (Action<HttpRequestMessage, CancellationToken>)AssertThatRequestCorrect)
                    .ReturnsAsync(mockedResult);
    
                //Act
                var actualResponse = await _client.SendAsync(_httpRequest);
    
                //check that internal call to SendAsync was only Once and with proper request object
                _testHandler
                    .Protected()
                    .Verify("SendAsync", Times.Once(), _httpRequest, ItExpr.IsAny<CancellationToken>());
    
                // if our custom handler modifies somehow our response we can check it here
                Assert.That(actualResponse.IsSuccessStatusCode, Is.True);
                Assert.That(actualResponse, Is.EqualTo(mockedResult));
                //...Other asserts
            }
        }
    } 
