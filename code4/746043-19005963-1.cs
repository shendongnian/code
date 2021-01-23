    public class BaseEntityMap : EntityTypeConfiguration<BaseEntity>
    {
        public BaseEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
    
            // Properties
            // Table & Column Mappings
            this.ToTable("BaseEntitySet");
            this.Property(t => t.Id).HasColumnName("Id")
    			.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // ...
        }
    }
    
    public class FooMap : EntityTypeConfiguration<Foo>
    {
        public FooMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
    
            // Table & Column Mappings
            this.ToTable("FooSet");
            this.Property(t => t.Id).HasColumnName("Id")
    			.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.MyEntityId).HasColumnName("MyEntity_Id");
    
            // Relationships
            this.HasRequired(t => t.MyEntity)
                .WithMany(t => t.Foos)
                .HasForeignKey(d => d.MyEntityId);
        }
    }
    
    public class BarMap : EntityTypeConfiguration<Bar>
    {
        public BarMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
    
            // Table & Column Mappings
            this.ToTable("BarSet");
            this.Property(t => t.Id).HasColumnName("Id")
    			.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.FooId).HasColumnName("Bar_Id");
    
            // Relationships
            this.HasRequired(t => t.Foo)
                .WithMany(t => t.Bars)
                .HasForeignKey(d => d.FooId);
        }
    }
