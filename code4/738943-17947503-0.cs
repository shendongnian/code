    public class BaseEntityLongConfiguration<T> : EntityTypeConfiguration<T> where T : BaseObjectLong {
        public BaseEntityLongConfiguration(DatabaseGeneratedOption DGO = DatabaseGeneratedOption.Identity) {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            //Id is an indent allocated by DB
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DGO); // default to db generated
            this.Property(t => t.RowVersion)   // for concurrency
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();
        }
    }
