     public abstract class BindableBase { }
       //base class for all tenant-scoped objects
       public abstract class TenantModelBase : BindableBase
       {
          [Key]
          public virtual int TenantId { get; set; }
       }
    
       public abstract class Order : TenantModelBase
       {
          public Customer Customer { get; set; } //works: mapped using TenantId and CustomerId
          public Product Product { get; set; } //again, works with TenantId and ProductId
          public string ProductId { get; set; }
          public string CustomerId { get; set; }
       }
       public class Customer : TenantModelBase
       {
          [Key]
          public string CustomerId { get; set; }
       }
    
       public class Product : TenantModelBase
       {
          [Key]
          public string ProductId { get; set; }
       }
    
       public class SpecialOrder : Order
       {
          [Key]
          public int SpecialOrderId { get; set; }
          public OtherClass OtherClass { get; set; } //this fails!, see below
          public string OtherClassId { get; set; }
       }
       public class SuperSpecialOrder : SpecialOrder { }
    
       public class OtherClass : TenantModelBase
       {
          public string OtherClassId { get; set; }
          public ICollection<SpecialOrder> SpecialOrders { get; set; }
       }
    
    
    
       public class Model : DbContext
       {
          public DbSet<Customer> Customers { get; set; }
          public DbSet<Product> Products { get; set; }
          public DbSet<SpecialOrder> SpecialOrders { get; set; }
          public DbSet<SuperSpecialOrder> SuperSpecialOrders { get; set; }
    
          public DbSet<OtherClass> OtherClasses { get; set; }
    
          protected override void OnModelCreating( DbModelBuilder modelBuilder )
          {
             modelBuilder.Entity<OtherClass>()
                .HasKey( k => new { k.TenantId, k.OtherClassId } );
    
             modelBuilder.Entity<Customer>()
                .HasKey( k => new { k.TenantId, k.CustomerId } );
    
             modelBuilder.Entity<Product>()
                .HasKey( k => new { k.TenantId, k.ProductId } );
            
    
             modelBuilder.Entity<SpecialOrder>()
                .Map( m =>
                         {
                            m.MapInheritedProperties();
                            m.ToTable( "SpecialOrders" );
                         } );
    
             modelBuilder.Entity<SpecialOrder>().HasKey( k => new { k.TenantId, k.SpecialOrderId } );
    
             modelBuilder.Entity<SuperSpecialOrder>()
              .Map( m =>
              {
                 m.MapInheritedProperties();
                 m.ToTable( "SuperSpecialOrders" );
              } )
              .HasKey( k => new { k.TenantId, k.SpecialOrderId } );
    
             modelBuilder.Entity<SpecialOrder>()
              .HasRequired( p => p.OtherClass )
              .WithMany( o => o.SpecialOrders )
              .HasForeignKey( p => new { p.TenantId, p.OtherClassId } );
    
             modelBuilder.Entity<Order>()
                .HasRequired( o => o.Customer )
                .WithMany()
                .HasForeignKey( k => new { k.TenantId, k.CustomerId } );
    
             modelBuilder.Entity<Order>()
              .HasRequired( o => o.Product )
              .WithMany()
              .HasForeignKey( k => new { k.TenantId, k.ProductId } );
    
             modelBuilder.Ignore<Order>();
    
    
          }
       }
