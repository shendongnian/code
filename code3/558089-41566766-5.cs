       protected override void OnModelCreating(DbModelBuilder modelBuilder)     
        {   
            // folowwing is also necessary in case you're using identity model     
            base.OnModelCreating(modelBuilder);               
            modelBuilder.Entity<UObjects>()       
                .HasOptional<UObjects>(u => u.UParent) // EF'll load Parent if any     
                .WithMany(u => u.UObjects);        // load all childs if any 
        }
