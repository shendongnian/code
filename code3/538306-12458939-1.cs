    internal class DocumentsConfiguration : EntityTypeConfiguration<Document>
    {
        public DocumentsConfiguration()
        {
            HasRequired(document => document.DocumentType)
                .WithMany()
                .Map(e => e.MapKey("DocumentId"));
            Property(document => document.Title).HasColumnName("Title").IsRequired();
            ToTable("Documents");
        }
    }
