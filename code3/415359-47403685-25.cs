    using System.Data;
    using DL.SO.Project.Domain.Repositories;
    namespace DL.SO.Project.Persistence.Dapper
    {
        public abstract class DbConnection2RepositoryBase
        {
            public IDbConnection DbConnection { get; private set; }
            public DbConnection2RepositoryBase(IDbConnectionFactory dbConnectionFactory)
            {
                this.DbConnection = dbConnectionFactory.CreateDbConnection(DatabaseConnectionName.Connection2);
            }
        }
    }
    using Dapper;
    using System.Data;
    namespace DL.SO.Project.Persistence.Dapper.Repositories
    {
        public class ParameterRepository : DbConnection2RepositoryBase, IParameterRepository
        {
            public ParameterRepository (IDbConnectionFactory dbConnectionFactory)
                : base(dbConnectionFactory) { }
            public IEnumerable<Parameter> GetAll()
            {
                const string sql = @"SELECT * FROM TABLE";
                return base.DbConnection.Query<Parameter>(sql);
            }
            // ......
        }
    }
