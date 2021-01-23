    [Test]
    public void ShouldNotAcceptInvalidUser()
    {
        // Arrange
        Mock<IMembershipService> membershipService = new Mock<IMembershipService>();
        membershipService.Setup(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(false);
        Mock<IFormsService> membershipService = new Mock<IFormsService>();
        var logonModel = new LogOnModel() { UserName = "", Password = "" };
        var controller = new AccountController(membershipService.Object, formsService.Object);
        // Act
        var result = controller.LogOn(logonModel, "") as ViewResult;
        // Assert
        Assert.False(controller.ModelState.IsValid);
        Assert.That(controller.ModelState[""], Is.EqualTo("The user name or password provided is incorrect."));
    }
