    public class SystemContext : DbContext
    	{
    		public DbSet<Stock> Stocks { get; set; }
    		public DbSet<RawDayValues> StockRawValues { get; set; }
    
    		public SystemContext()
    			: base("Server=localhost;Database=test;Trusted_Connection=True;") 
    		{ }
    
    		public class SystemInitializer : DropCreateDatabaseIfModelChanges<SystemContext>
    		{
    			#region SEED
                // This is what you're looking for!
    			protected override void Seed(SystemContext context)
    			{
    				try
    				{
    					var stock = new Stock() { Symbol = "TEST" };
    					context.Stocks.Add(stock);
    					context.SaveChanges();
    				}
    				catch (Exception ex) { Console.Error.WriteLine(ex.Message); }
    				base.Seed(context);
    			}
    
    			#endregion
    		}
    	}
