        [TestMethod]
        public void RetrieveKeyFnTest1()
        {
            StegApp target = new StegApp(); // this creates your context. I'm assuming it also creates your RetrieveLogs object, etc
            var username = "UserWithNotMessages"; //this user should exist in your database but should not have any messages. You could insert this user as part of your TestInitialize method
            var password = "UserWithNotMessagesPassword"; //this should be the proper password
            var message = target.RetrieveKeyFn(username, password);
            Assert.AreEqual (-1, message.LogId);
        }
