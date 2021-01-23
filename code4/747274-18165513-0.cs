    public class BooMapper : EntityTypeConfiguration<Boo>
    {
        public BooMapper()
        {
            //...
            this.HasMany(t => t.FooBoo)
                .WithRequired(fb => fb.Boo)
                .HasForeignKey(t => t.Booid);
        }
    }
    public class FooMapper : EntityTypeConfiguration<Foo>
    {
        public FooMapper()
        {
            //...
            this.HasMany(t => t.FooBoo)
                .WithRequired(fb => fb.Foo)
                .HasForeignKey(t => t.Booid);
        }
    }
