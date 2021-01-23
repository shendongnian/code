[TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Post_Test()
        {
           //Arrange
           var contoller = new PostController();  //the contoller which you want to test
           controller.Request = new HttpRequestMessage();
           controller.Configuration = new HttpConfiguration();
           // Act
           var response = controller.Post(new Number { PhNumber = 9866190822 });
           // Number is the Model name and PhNumber is the Model Property for which you want to write the unit test
           //Assert
           var request = response.StatusCode;
           Assert.AreEqual("Accepted", request.ToString());
        }
    }
Similarly according to the need change the HttpResponseMessage in the Assert.
