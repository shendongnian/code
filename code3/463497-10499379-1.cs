    public ActionResult Index()
    {
        // that's your domain model => a list of UsersClass
        // could be coming from wherever you want
        var users = Enumerable.Range(1, 7).Select(x => new UsersClass
        {
            Id = x
        });
        // Now let's group those users into the view model:
        // We will have 5 elements per row
        var model = users
            .Select((u, index) => new { User = u, Index = index })
            .GroupBy(x => x.Index / 5)
            .Select(x => new MyViewModel
            {
                Key = x.Key,
                Users = x.Select(y => y.User)
            });
        return View(model);
    }
