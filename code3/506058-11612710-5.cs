    [Test]
    public void ShouldNotAcceptInvalidUser()
    {
        // Arrange
        Mock<IMembershipService> membership = new Mock<IMembershipService>();
        membership.Setup(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(false);
        Mock<IFormsService> forms = new Mock<IFormsService>();
        var logonModel = new LogOnModel() { UserName = "", Password = "" };
        var controller = new AccountController(membership.Object, forms.Object);
        // Act
        var result = controller.LogOn(logonModel, "") as ViewResult;
        // Assert
        Assert.That(result.ViewName, Is.EqualTo("Index"));
        Assert.False(controller.ModelState.IsValid);
        Assert.That(controller.ModelState[""], 
                    Is.EqualTo("The user name or password provided is incorrect."));
    }
