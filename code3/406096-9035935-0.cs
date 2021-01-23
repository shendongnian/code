    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Common;
    using System.Configuration;
    using System.Data;
    using EventStore.Persistence.SqlPersistence;
    using EventStore.Persistence;
    
    namespace Project.Factories
    {
        public class ConnectionStringConnectionFactory : IConnectionFactory
        {
            private static readonly IDictionary<string, DbProviderFactory> CachedFactories =
                new Dictionary<string, DbProviderFactory>();
    
            private string m_connectionString;
            private string m_providerName;
    
            private string m_replicaConnectionString;
            private string m_replicaProviderName;
    
            public ConnectionStringConnectionFactory(string connectionString, string providerName)
                : this(connectionString, providerName, connectionString, providerName)
            {
    
            }
    
            public ConnectionStringConnectionFactory(
                string connectionString,
                string providerName,
                string replicaConnectionString,
                string replicaProviderName)
            {
                m_connectionString = connectionString;
                m_providerName = providerName;
                m_replicaConnectionString = replicaConnectionString;
                m_replicaProviderName = replicaProviderName;
            }
    
    
            public virtual IDbConnection OpenMaster(Guid streamId)
            {
                return this.Open(streamId, m_connectionString, m_providerName);
            }
    
            public virtual IDbConnection OpenReplica(Guid streamId)
            {
                return this.Open(streamId, m_replicaConnectionString, m_replicaProviderName);
            }
    
            protected virtual IDbConnection Open(Guid streamId, string connectionString, string providerName)
            {
                return new ConnectionScope(connectionString, () => this.Open(connectionString, providerName));
            }
    
            protected virtual IDbConnection Open(string connectionString, string providerName)
            {
                var factory = this.GetFactory(providerName);
                var connection = factory.CreateConnection();
                if (connection == null)
                    throw new ConfigurationErrorsException("Invalid provider name");
    
                connection.ConnectionString = connectionString;
    
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    throw new StorageUnavailableException(e.Message, e);
                }
    
                return connection;
            }
    
            protected virtual DbProviderFactory GetFactory(string providerName)
            {
                lock (CachedFactories)
                {
                    DbProviderFactory factory;
                    if (CachedFactories.TryGetValue(providerName, out factory))
                        return factory;
    
                    factory = DbProviderFactories.GetFactory(providerName);
                    return CachedFactories[providerName] = factory;
                }
            }
    
            public ConnectionStringSettings Settings
            {
                get { return new ConnectionStringSettings("Default", m_connectionString, m_providerName); }
            }
        }
    }
