    public class PositionConfiguration : EntityTypeConfiguration<Position>
    {
        public PositionConfiguration()
        {
            this.ToTable("Positions");
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasColumnName("PositionId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
            this.Property(p => p.CompanyName).HasColumnName("CompanyName");
            this.Property(p => p.EndMonth).IsOptional().HasColumnName("EndMonth");
            this.Property(p => p.EndYear).IsOptional().HasColumnName("EndYear");
            this.Property(p => p.IsCurrentRole).IsOptional().HasColumnName("IsCurrentRole");
            this.Property(p => p.StartMonth).IsOptional().HasColumnName("StartMonth");
            this.Property(p => p.StartYear).IsOptional().HasColumnName("StartYear");
    
            this.Property(p => p.Summary).HasColumnName("Summary");
            this.Property(p => p.Title).HasColumnName("Title");
        }
    }
