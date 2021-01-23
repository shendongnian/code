    [TestMethod]
    public void IndexTest()
    {
        var sessionManager = new Mock<ISessionManager>(); // Mock dependency
        sessionManager.Setup(m => m.CustomerID).Returns(42);
        
        const int page = 1;
        const string sortBy = "FirstName";
        const bool ascending = true;
        const string partname = ""; 
        const int success = -1;
        const string id = "";
        var expectedModelType = typeof(ParticipantListViewModel);
        ParticipantController pCTarget = 
             new ParticipantController(sessionManager.Object); // Inject dependency
        var view = pCTarget.Index(page, sortBy, ascending, partname, success, id)
                   as ViewResult;
        sessionManager.VerifyGet(m => m.CustomerID); // Verify dependency was called
        Assert.AreEqual(expectedModelType, view.Model.GetType());
    }
