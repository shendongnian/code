    [TestMethod]
    public void TestLogin_InvalidModel()
    {
        AccountController controller = CreateAccountController();
        // new code added -->
        controller.ModelState.AddModelError("fakeError", "fakeError");
        // end of new code
        ...
        var response = controller.PostLogin(new LoginModel() {  });
    
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    
    }
