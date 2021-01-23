    public enum MyEnum
    { 
        Value1, Value2
    }
    
    public class MyBaseClass
    { 
        [NotMapped]
        public MyEnum PaymentId { get; protected set; }
    }
    
    public class DerivedOne: MyBaseClass
    {
        public DerivedOne()
        {
            PaymentId = MyEnum.Value1;
        } 
    }
    
    public class DerivedTwo: MyBaseClass
    {
        public DerivedTwo()
        {
            PaymentId = MyEnum.Value2;
        }
    }
    
    public class MyDbContext : DbContext
    {
        DbSet<MyBaseClass> MyBaseClass { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MyBaseClass>()
                .Map<DerivedOne>(x => x.Requires("PaymentId").HasValue((int)PaymentId.Value1))
                .Map<DerivedTwo>(x => x.Requires("PaymentId").HasValue((int)PaymentId.Value2));
        }
    }
