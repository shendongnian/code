    var user1 = new User("Chriss");
    var user2 = new User("Jena");
    var userModel1 = new UserViewModel(user1);
    var userModel2 = new UserViewModel(user2);
    var group = new Group(userModel1 , userModel2);
    var project = new ProjectViewModel();
    project.Groups.Add(new GroupViewModel(group));
