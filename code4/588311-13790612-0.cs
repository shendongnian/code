     public class DataCatalog : DbContext
        {
            public static string ConnectionString { get; set; }
         
            public DataCatalog() : base(ConnectionString ?? "PawLoyalty")
            {
    
            }  
        }
