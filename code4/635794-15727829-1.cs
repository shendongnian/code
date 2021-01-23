    public class HOLContextFactory
    {
        public static HOLDbEntities Create()
        {
            // default connection string
            return new HOLDbEntities(); 
        }
        public static HOLDbEntities CreateQuote()
        {
            // specified connection string
            return new HOLDbEntities ("HOLDbQuoteEntities"); 
        }
    }
    public partial class HOLDbEntities
    {
        public HOLDbEntities(string connectionString)
            : base(connectionString) 
            {
            }
        }
    }
