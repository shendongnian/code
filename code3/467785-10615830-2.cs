    Mock<IDbFactoryDatabaseConnection> connectionMock = new Mock<IDbFactoryDatabaseConnection>();
    
    DbProviderFactoryConnection aDbProviderFactoryConnection = new DbProviderFactoryConnection(connectionString, provider, connectionMock.Object);
    
    connectionMock.Setup(c => c.Close()).Throws<Exception>();
    
    DbFactoryResponseType dbFactoryResponseType = aDbProviderFactoryConnection.Close();
