        [TestMethod]
        public void TestCreateUser()
        {
           try
           {
              AsaMembershipProvider prov = this.GetMembershipProvider();
              //call get user
              MembershipCreateStatus status;
              MembershipUser user = prov.CreateUser("testUserX", "12345", "test.UserX@abc.com", "", "", true, null, out status);
              //Assert.AreNotEqual(status, MembershipCreateStatus.Success);
              if (status != MembershipCreateStatus.Success)
                  throw new Exception("Error message you want goes here for this case.");
              var isAuthenticated = prov.ValidateUser(user.UserName, "12345");
              //Assert.IsTrue(isAuthenticated);
              if (!isAuthenticated)
                  throw new Exception("Error message you want goes here for this case.");
              //Assert.AreEqual(user.UserName, "testUserX");
              if (user.UserName != "testUserX")
                  throw new Exception("Error message you want goes here for this case.");
              //Assert.AreEqual(user.Email, "test.userx@abc.com");
              if (user.Email != "test.userx@abc.com")
                  throw new Exception("Error message you want goes here for this case.");
              //Assert.IsTrue(user.CreationDate==DateTime.Now);
              if (user.CreationDate != DateTime.Now)
                  throw new Exception("Error message you want goes here for this case.");
              //TODO Asserts
           }
