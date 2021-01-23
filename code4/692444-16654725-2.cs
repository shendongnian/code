        public override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Place.PlaceMapping());
            // Any other configurations added here the same way
        }
