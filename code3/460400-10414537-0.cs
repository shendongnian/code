    [TestMethod]
    public void ChangePassword_Action_Should_Be_Accessible_Only_To_Users_Belonging_To_The_RoleToTest_Role()
    {
        Expression<Func<AccountController, ActionResult>> changePwdEx = 
            x => x.ChangePassword(null);
        var authorize = (changePwdEx.Body as MethodCallExpression)
            .Method
            .GetCustomAttributes(typeof(AuthorizeAttribute), true)
            .OfType<AuthorizeAttribute>()
            .First();
        Assert.AreEqual("RoleToTest", authorize.Roles);
    }
