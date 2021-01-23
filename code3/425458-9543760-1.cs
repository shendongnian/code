    public class ParentConfiguration : EntityTypeConfiguration<ParentClass>
    {
        public ParentConfiguration()
        {
            ToTable("Parent");
        }
    }
    public class FooConfiguration : EntityTypeConfiguration<Foo>
    {
        public FooConfiguration()
        {
            Map(m =>
            {
                m.Requires("IsActive").HasValue(1);
                m.Requires("Type").HasValue("Foo");
            });
        }
    }
    public class BarConfiguration : EntityTypeConfiguration<Bar>
    {
        public BarConfiguration()
        {
            Map(m =>
            {
                m.Requires("IsActive").HasValue(1);
                m.Requires("Type").HasValue("Bar");
            });
        }
    }
