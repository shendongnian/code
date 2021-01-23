    using Dapper;
    using System.Data;
    namespace DL.SO.Project.Persistence.Dapper.Repositories
    {
        public class DiameterRepository : IDiameterRepository
        {
            private readonly IDbConnection _dbConnection;
            public DiameterRepository(IDbConnection dbConnection)
            {
                _dbConnection = dbConnection;
            }
            public IEnumerable<Diameter> GetAll()
            {
                const string sql = @"SELECT * FROM TABLE";
                // No need to use using statement. Dapper will automatically
                // open, close and dispose the connection for you.
                return _dbConnection.Query<Diameter>(sql);
            }
            // ......
        }
    }
