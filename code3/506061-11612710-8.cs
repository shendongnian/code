    [Test]
    public void ShouldRedisplayViewWhenModelIsNotValid()
    {
       // Arrange        
       Mock<IMembershipService> membership = new Mock<IMembershipService>();
       Mock<IFormsService> forms = new Mock<IFormsService>();
       var model = new LogOnModel() { UserName = "", Password = "" };
       var controller = new AccountController(membership.Object, forms.Object);
       controller.ModelState.AddModelError("key", "error message");
       // Act
       var result = controller.LogOn(model, "") as ViewResult;
       // Assert
       Assert.That(result.ViewName, Is.EqualTo("LogOn"));
    }
    [Test]
    public void ShouldSignInAndRedirectToIndex()
    {
       // Arrange        
       Mock<IMembershipService> membership = new Mock<IMembershipService>();
      membership.Setup(m => m.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                 .Returns(true);
       Mock<IFormsService> forms = new Mock<IFormsService>();
       var model = new LogOnModel() { UserName = "", Password = "" };
       var controller = new AccountController(membership.Object, forms.Object);
       controller.ModelState.AddModelError("key", "error message");
       // Act
       var result = controller.LogOn(model, "") as ViewResult;
       // Assert
       forms.Verify(f => f.SignIn(model.UserName, model.RememberMe));
       Assert.That(result.ViewName, Is.EqualTo("Index"));
    }
