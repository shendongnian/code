    [TestMethod]
        public void Delete()
        {
            taskModelContainer db = new taskModelContainer();
            int userID = 41;
            TaskMgr.Models.User UserEntity = new TaskMgr.Models.User();
            UserEntity.userID = userID;
            UserController User = new UserController();
            ActionResult result = User.DeleteConfirmed(UserEntity.userID);
            var del = from e in db.Users where e.userID == UserEntity.userID select e;
            var delete = del.Count();
            Assert.AreEqual(0, delete);
        }
