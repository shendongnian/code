    public sealed class EntityDefaultContext : DbContext {    
        /// <summary>
        /// Model Creating Event Handler.
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            var entityCaptureConfiguration = new EntityCaptureConfiguration();
            var entityOperatingSystemConfiguration = new EntityOperatingSystemConfiguration();
    
            modelBuilder.Configurations.Add(entityOperatingSystemConfiguration);
            modelBuilder.Configurations.Add(entityCaptureConfiguration);
    
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
