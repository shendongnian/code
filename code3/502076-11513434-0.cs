        [TestMethod, HostType("Moles")]
        public void EditUserInfoTest()
        {  
            var testUserName = "TestUser";
            var controller = new UserEditorController();
            using (MolesContext.Create())
            {
                var user = new MMembershipUser
                {
                    UserNameGet = () => "TestUser",
                    EmailGet = () => "test@test.test"
                };        
                MMembership.GetUserString = (userName) =>
                {
                    Assert.AreEqual(testUserName, userName);
                    return user;
                };
                var result = (ViewResult)controller.Edit(testUserName);                
                Assert.AreNotEqual("Error", result.ViewName);
            }
        }
