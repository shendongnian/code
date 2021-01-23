    public enum MyEnum
    { 
        Value1, Value2
    }
    
    public class MyBaseClass
    { 
        [NotMapped]
        public MyEnum MyEnum { get; protected set; }
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MyBaseClass>()
                .Map<DerivedOne>(x => x.Requires("MyEnum").HasValue((int)MyEnum.Value1))
                .Map<DerivedTwo>(x => x.Requires("MyEnum").HasValue((int)MyEnum.Value2));
        }
    }
