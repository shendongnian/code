    public ApplicationMap()
    {
       Id(x => x.Id);
       Map(x => x.Name);
       HasManyToMany(x => x.User)
           .Table("Access")
           .ParentKeyColumn("application_fk")
           .ChildKeyColumn("user_fk")
           .Cascade.All();
    }
