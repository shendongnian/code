		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Mappings.BaseMapping<SomeOtherModel>());
            modelBuilder.Configurations.Add(new Mappings.MyCoolModelMapping());
			//Other logic
        }
	
