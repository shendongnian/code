     Assert.AreEqual(status, MembershipCreateStatus.Success);
            
     var isAuthenticated = Membership.ValidateUser(user.Username, "12345");
     Assert.IsTrue(isAuthenticated);
     Assert.AreEqual(user.UserName, "testUserX");
     Assert.AreEqual(user.Email, "test.userx@abc.com");
