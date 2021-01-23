    [TestMethod]
    public void Edit_Post_Action_Updates_Model_And_Redirects()
    {
    	// Arrange
    	var mockBusinessRepository = new Mock<IBusinessRepository>();
    	var fromDB = new Business { Id = "1", Name = "Test" };
    	var expected = new Business { Id = "1", Name = "Not Test" };
    
    	// Set up result for business repository
    	mockBusinessRepository.Setup(m => m.Get(fromDB.Id)).Returns(fromDB);
    	mockBusinessRepository.Setup(m => m.Save(It.IsAny<Business>())).Returns(expected);
    	var businessController = new BusinessController(mockBusinessRepository.Object) {ControllerContext = new ControllerContext()};
    	
    	//Act
    	var result = businessController.Edit(fromDB.Id, expected) as RedirectToRouteResult;
    	
    	// Assert
    	Assert.IsNotNull(result);
    	Assert.AreEqual(result.RouteValues["action"], "Index");
    	mockBusinessRepository.VerifyAll();
    }
