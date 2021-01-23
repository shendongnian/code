    using System;
    using System.Data.Entity;
    using System.Data.Services;
    using System.Data.Services.Common;
    using System.ServiceModel;
    
    namespace Scratch.Web
    {
        // 4
        [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
        // 1
        public class ScratchService : DataService<ScratchContext>
        {
            static ScratchService()
            {
                // 2
                Database.SetInitializer(new ScratchContextInitializer());
            }
    
            public static void InitializeService(DataServiceConfiguration config)
            {
                // 3
                config.SetEntitySetAccessRule("*", EntitySetRights.All);
                config.SetServiceOperationAccessRule("*", ServiceOperationRights.AllRead);
                config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
                // 4
                config.UseVerboseErrors = true;
            }
        }
    
        public class ScratchContextInitializer : DropCreateDatabaseIfModelChanges<ScratchContext>
        {
            protected override void Seed(ScratchContext context)
            {
                base.Seed(context);
                // 5
                context.Products.Add(new DiscontinuedProduct
                                         {
                                             Name = "DP1",
                                             DiscontinuedAt = DateTime.Now.AddDays(-7)
                                         });
                context.Products.Add(new DiscountedProduct
                                         {
                                             Name = "DP1",
                                             Discount = 3.14
                                         });
            }
        }
        // 6
        public class ScratchContext : DbContext
        {
            public DbSet<Product> Products { get; set; }
        }
        // 7
        public abstract class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        // 7
        public class DiscountedProduct : Product
        {
            public double Discount { get; set; }
        }
        // 7
        public class DiscontinuedProduct : Product
        {
            public DateTime DiscontinuedAt { get; set; }
        }
    }
