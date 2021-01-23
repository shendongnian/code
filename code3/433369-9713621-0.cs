    [Test]
    public void IsValidDoer_DoerIsValid()
    {
      var mockRepository = new Mock<IDoerRepository>();
      var activeDoers = CreateSpecificDoerList();
      mockRepository.Setup(r => r.ActiveDoers).Returns(activeDoers);
      
      var doerValidation = new DoerValidation(mockRepository.Object);
      
      // Assert things
    }
