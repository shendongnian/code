    using System.Data.Entity.Infrastructure;<br/>
    ...<br/>
    public sealed class NpgsqlFactory : DbProviderFactory, IServiceProvider, IDbConnectionFactory<br/>
    ...<br/>
    public DbConnection CreateConnection(string nameOrConnectionString)<br/>
    {<br/>
          return new NpgsqlConnection(nameOrConnectionString);<br/>
    }<br/>
