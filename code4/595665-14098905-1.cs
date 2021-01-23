    var container = new Container(x =>
    {
        x.For(typeof(IRepository<Facility>))
            .Use(typeof(Repository<Facility>))
                .Child<ISessionFactory>()
                    .IsNamedInstance("CoolSessionFactory");
    });
