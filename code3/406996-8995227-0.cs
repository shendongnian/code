    public string TestCRUD()
    {
        UserService userService = UserServiceFactory.GetService();
        User user = new User("Test", "Test", "Test", "TestUser") { Groups = new Collection<Group>() };
        GroupType groupType = new GroupType("TestGroupType2", null);
        Group group = new Group("TestGroup2", null) { GroupType = groupType };
        user.Groups.Add(group);
        userService.Save(user);
    }
