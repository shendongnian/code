        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasManyToMany(x => x.Application)
               .Table("Access")
               .ParentKeyColumn("user_fk")
               .ChildKeyColumn("application_fk")
               .Inverse()            // this is essential
               .Cascade.All();
        }
