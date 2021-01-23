    using System.Data;
    namespace DL.SO.Project.Domain.Repositories
    {
        public interface IDbConnectionFactory
        {
            IDbConnection CreateDbConnection(DatabaseConnectionName connectionName);
        }
    }
