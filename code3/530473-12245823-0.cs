    var settings = new Settings();
    settings.PrintName = false;
    var dbContext = new MyDbContext();
    var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
    objectContext.ObjectMaterialized += (sender, e) => {
        var user = e.Entity as User;
        if (e != null) {
           // Now you can call your initialization logic
           user.Settings = settings;
        }
    };
    var john = dbContext.Users.Where(x => x.Name == "John").FirstOrDefault();
    Assert.AreEqual(john.Settings, settings);
