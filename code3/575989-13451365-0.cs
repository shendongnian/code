    [Fact]
    public void GetPolicies()
    {
       // Arrange
       var mockService = new Mock<IHOLService>();
       Policy expectedPolicy = new Policy(); // substitute for the real way you construct these
       List<Policy> policy = new List<Policy>() { expectedPolicy };
       mockService.Setup(cr => cr.GetAllPolicies(10, 0)).Returns(policy);
       // Act
       var result = (ViewResult)controller.Index();
       var model = result.ViewData.Model; // equals 0.
       // Assert
       var listCategories = Assert.IsAssignableFrom<List<Policy>>(result.ViewData.Model);
       Assert.Equal(expectedPolicy, listCategories.First());        
    }
