    public enum MyEnum
    { 
        Value1, Value2
    }
    public class MyBaseClass
    { 
        public MyEnum { get; protected set; }
    }
    public class DerivedOne: MyBaseClass
    {
        public DerivedOne()
        {
            MyEnum = MyEnum.Value1;
        } 
    }
    public class DerivedTwo: MyBaseClass
    {
        public DerivedTwo()
        {
            MyEnum = MyEnum.Value2;
        }
    }
    public class MyDbContext : DbContext
    {
        DbSet<MyBaseClass> MyBaseClass { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .Add(new DerivedOneConfiguration())
                .Add(new DerivedTwoConfiguration());
        }
    }
    public class DerivedOneConfiguration : EntityTypeConfiguration<DerivedOne>
    {
        public DerivedOneConfiguration()
        {
            Map<DerivedOne>(_ => _.Requires("MyEnum").HasValue((int)MyEnum.Value1).IsRequired());
        }
    }
    public class DerivedTwoConfiguration : EntityTypeConfiguration<DerivedTwo>
    {
        public DerivedTwoConfiguration()
        {
            Map<DerivedTwo>(_ => _.Requires("MyEnum").HasValue((int)MyEnum.Value2).IsRequired());
        }
    }
