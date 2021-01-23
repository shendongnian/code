    public class sysdtslog90Map : EntityTypeConfiguration<sysdtslog90>
    {
        public sysdtslog90Map()
        {
            // Primary Key
            this.HasKey(t => t.id);
    
            // Properties
            this.Property(t => t.@event)
                .IsRequired()
                .HasMaxLength(128);
    
            this.Property(t => t.@operator)
                .IsRequired()
                .HasMaxLength(128);
