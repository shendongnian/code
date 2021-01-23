    public ActionResult Index()
    {
        using (var ctx = new UsersContext())
        using (var cmd = ctx.Database.Connection.CreateCommand())
        {
            ctx.Database.Connection.Open();
            cmd.CommandText = "SELECT * FROM UserProfile";
            using (var reader = cmd.ExecuteReader())
            {
                var model = Read(reader).ToList();
                return View(model);
            }
        }
    }
