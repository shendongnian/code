    using Dapper;
    using System.Data;
    namespace DL.SO.Project.Persistence.Dapper.Repositories
    {
        // Move the responsibility of picking the right connection string
        //   into an abstract base class so that I don't have to duplicate
        //   the right connection selection code in each repository.
        public class DiameterRepository : DbConnection1RepositoryBase, IDiameterRepository
        {
            public DiameterRepository(IDbConnectionFactory dbConnectionFactory)
                : base(dbConnectionFactory) { }
            public IEnumerable<Diameter> GetAll()
            {
                const string sql = @"SELECT * FROM TABLE";
                // No need to use using statement. Dapper will automatically
                // open, close and dispose the connection for you.
                return base.DbConnection.Query<Diameter>(sql);
            }
            // ......
        }
    }
