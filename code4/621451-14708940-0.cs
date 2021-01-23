    using System.Data.Entity;
    using System.Linq;
    namespace EF_DEMO
    {
    class Program
    {
        static void Main(string[] args) {
            var ctx = new DemoContext();
            var ord =  ctx.Orders.FirstOrDefault();
            //. DB should be there now...
        }
    }
    public class Order
    {
    public int Id {get;set;}
    public string Code {get;set;}
    public int? QuotationId { get; set; }   //optional  since it is nullable
    public virtual Quotation Quotation { get; set; }
      //....
    }
    public class Quotation
    {
     public int Id {get;set;}
     public string Code{get;set;}
    // public int? OrderId { get; set; }   //optional  since it is nullable
     public virtual Order Order { get; set; }
     //...
    }
    public class DemoContext : DbContext
    {
        static DemoContext()
        {
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DemoContext>());
        }
        public DemoContext()
            : base("Name=Demo") { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
   
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Order>().HasKey(t => t.Id)
                        .HasOptional(t => t.Quotation)
                        .WithOptionalPrincipal(d => d.Order)
                        .Map(t => t.MapKey("OrderId"));  // declaring here  via MAP means NOT declared in POCO
            modelBuilder.Entity<Quotation>().HasKey(t => t.Id)
                        .HasOptional(q => q.Order)
                // .WithOptionalPrincipal(p => p.Quotation)  //as both Principals
                //        .WithOptionalDependent(p => p.Quotation) // as the dependent
                //         .Map(t => t.MapKey("QuotationId"));    done in POCO.
                ;
        }   
    }
    }
