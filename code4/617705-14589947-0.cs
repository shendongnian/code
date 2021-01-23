    using (var context = new UnicornsContext())
    {
        var unicorn = new Unicorn { Name = "Franky", PrincessId = 1};
        context.Unicorns.Add(unicorn); // your missing line
        context.SaveChanges();
    }
