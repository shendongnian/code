    [TestMethod]
    public void TestGetUser()//Shell Complete, test code needs review
    {
        try
        {
            //set test to get user 
            AsaMembershipProvider prov = this.GetMembershipProvider();
            //call get user
            MembershipUser user = prov.GetUser("test.user", false);
            //ask for the username with deliberate case differences
             MembershipUser user2 = prov.GetUser("TeSt.UsEr", false);
            //prove that you still get the user,
            Assert.AreNotEqual(null, user);
            Assert.AreNotEqual(null, user2);
            //test by using the “.ToLower()” function on the resulting string.
            //verify case doesn’t matter on username.
            Assert.AreEqual(user.UserName.ToLower(), user2.UserName.ToLower());
            Assert.AreEqual(user.UserName.ToLower(), "test.user");
         }
    catch (Exception ex)
        {
            LogMessage(ex);
            Assert.Fail(ex.Message);
        }
    }
