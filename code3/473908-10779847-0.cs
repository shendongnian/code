    using(var context = new MyDbContext())
    {
        var app = context.Applications.Single(a=>a.Id == theAppIdImInterestedIn); 
        app.Tasks.Add(new Task{ Name = "some other data" });
        context.SaveChanges();
    }
