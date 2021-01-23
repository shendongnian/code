    var state = ((IObjectContextAdapter)context)
                .ObjectContext
                .CreateObjectSet<Province>("States") as ObjectQuery<Province>;
                // States is entitySetName
    int count = state.Cities.Include("ElectricPosts.Employees")
                        .SelectMany(c => c.Posts)
                        .SelectMany(p => p.Employees)
                        .Count();
