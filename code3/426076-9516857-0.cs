    var user1 = new UserViewModel("Chriss");
    var user2 = new UserViewModel("Jena");
    var group = new Group(user1, user2);
    var project = new ProjectViewModel();
    project.Groups.Add(new GroupViewModel(group));
