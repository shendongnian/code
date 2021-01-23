    internal sealed class EntityCaptureConfiguration : EntityTypeConfiguration<Capture> {
        /// <summary>
        /// Create an Entity Capture Configuration.
        /// </summary>
        public EntityCaptureConfiguration() {
            this.ToTable("Capture");
            this.HasKey(m => m.Id);
            
            this.Property(m => m.Id).HasColumnName("Id");
    
            this.HasRequired(m => m.OperatingSystem).WithRequiredDependent().Map(m => m.MapKey("OperatingSystemId"));
        }
    }
