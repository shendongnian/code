    var user = new User { Name = "Joe" };
    session.Store(user);
    var fooBar = new FooBar { Name = "Whatever" };
    session.Store(fooBar);
    Debug.WriteLine(user.Id);
    Debug.WriteLine(fooBar.Id);
