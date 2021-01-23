    public partial class FashionShopContext : DbContext, IUnitOfWork
    {
       
       public static string ConnectionString { get; set; }
     
       public FashionShopContext() : base(ConnectionString ?? "FashionShopData")
        {
    
        }
    }
