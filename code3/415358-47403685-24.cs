    using System.Data;
    using DL.SO.Project.Domain.Repositories;
    namespace DL.SO.Project.Persistence.Dapper
    {
        public abstract class DbConnection1RepositoryBase
        {
            public IDbConnection DbConnection { get; private set; }
            public DbConnection1RepositoryBase(IDbConnectionFactory dbConnectionFactory)
            {
                // Now it's the time to pick the right connection string!
                // Enum is used. No magic string!
                this.DbConnection = dbConnectionFactory.CreateDbConnection(DatabaseConnectionName.Connection1);
            }
        }
    }
