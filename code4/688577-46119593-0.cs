    public partial class QueryModel : DbContext
    {
        public QueryModel(string connectionName):base(connectionName)
        {
            this.Database.Connection.Open();
        }
    }
