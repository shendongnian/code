    Mock<IDbFactoryDatabaseCommand> commandMock = new Mock<IDbFactoryDatabaseCommand>();
    
    DbProviderFactoryConnection aDbProviderFactoryConnection = new DbProviderFactoryConnection(connectionString, provider, commandMock.Object);
    
    commandMock.Setup(c => c.Close()).Throws<Exception>();
    
    DbFactoryResponseType dbFactoryResponseType = aDbProviderFactoryConnection.Close();
