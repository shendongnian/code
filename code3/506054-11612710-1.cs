    [Test]
    public void ShouldNotAcceptInvalidUser()
    {
        Mock<IMembershipService> membershipService = new Mock<IMembershipService>();
        membershipService.Setup(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(false);
        // create LogOnMocel and IFormsService mock
        var controller = new AccountController(membershipService.Object, formsService.Object);
        var result = controller.LogOn(logonModel, "") as ViewResult;
        Assert.False(controller.ModelState.IsValid);
        Assert.That(controller.ModelState[""], Is.EqualTo("The user name or password provided is incorrect."));
        // other assertions
    }
