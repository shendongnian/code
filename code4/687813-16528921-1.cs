    [TestMethod]
    public void TestCreateUser()
    {
        AsaMembershipProvider prov = this.GetMembershipProvider();
        //call get user
        MembershipCreateStatus status;
        MembershipUser user = prov.CreateUser("testUserX", "12345", "test.UserX@abc.com", "", "", true, null, out status);
        //Assert.AreNotEqual(status, MembershipCreateStatus.Success);
        if (status != MembershipCreateStatus.Success)
            Assert.Fail("Error message you want goes here for this case.");
        var isAuthenticated = prov.ValidateUser(user.UserName, "12345");
        //Assert.IsTrue(isAuthenticated);
        if (!isAuthenticated)
            Assert.Fail("Error message you want goes here for this case.");
        //Assert.AreEqual(user.UserName, "testUserX");
        if (user.UserName != "testUserX")
            Assert.Fail("Error message you want goes here for this case.");
        //Assert.AreEqual(user.Email, "test.userx@abc.com");
        if (user.Email != "test.userx@abc.com")
            Assert.Fail("Error message you want goes here for this case.");
        //Assert.IsTrue(user.CreationDate==DateTime.Now);
        if (user.CreationDate != DateTime.Now)
            Assert.Fail("Error message you want goes here for this case.");
    }
