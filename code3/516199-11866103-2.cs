    internal class ForSomeClassEntities : EntityTypeConfiguration<SomeClass> {
        public ForSomeClassEntities(String schemaName) {
            this.HasRequired(e => e.Category)
                .WithMany()
                .Map(map => map.MapKey("CategoryId"));
            this.ToTable("SomeClass", schemaName);
        }
    }
