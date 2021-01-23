    public class HOLContextFactory
    {
        public static HOLDbEntities Create()
        {
            return new HOLDbEntities(); // default connection string
        }
        public static HOLDbEntities CreateQuote()
        {
            return new HOLDbEntities ("HOLDbQuoteEntities"); // specified connection string
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
