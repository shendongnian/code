    [TestMethod]
    public void UserContainPermission_WhenNoPermissions_ReturnFalse()
    {
      var mockUser = new Mock<User>();
      mockUser.SetupGet(p => p.Permissions).Returns(
        () => new List<Permission>());
      var user = mockUser.Object;
      var isContainPermission = user.ContainPermission("Name");
      Assert.IsFalse(isContainPermission);
    }
