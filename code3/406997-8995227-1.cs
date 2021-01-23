    public string TestCRUD()
    {
        //Expecting that we use IoC or a factory to share the same DbContext on both 
        //services to avoid already attached or any other weird problems
        UserService userService = UserServiceFactory.GetService();
        GroupTypeService groupTypeService = GroupTypeServiceFactory.GetService();
        GroupType groupType = new GroupType("TestGroupType", null);
        groupTypeService.Save(groupType);
        /*now if the groupType object has changed its EntityState to Unchanged
        we won't do anything, if not: 
        a) get it from the db or b) set the EntityState manually */
        User user = new User("Test", "Test", "Test", "TestUser") { Groups = new Collection<Group>() };
        Group group = new Group("TestGroup", null) { GroupType = groupType };
        Group group2 = new Group("TestGroup2", null) { GroupType = groupType };
        user.Groups.Add(group);
        user.Groups.Add(group2);
        userService.Save(user);
    }
