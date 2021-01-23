    var mockDatabaseSessionFactory = new Mock<DatabaseSessionManager>(MockBehavior.Strict);
    var mockSession = new Mock<ISession>(MockBehavior.Strict);
    var mockTransaction = new Mock<ITransaction>(MockBehavior.Strict);
    
    mockDatabaseSessionFactory.Setup(x => x.GetIndividualMapDbSession()).Returns(mockSession.Object);
    mockDatabaseSessionFactory.Setup(x => x.GetIndividualDbSession(It.IsAny<UInt32>())).Returns(mockSession.Object);
    mockDatabaseSessionFactory.Setup(x => x.Dispose());
    mockSession.Setup(x => x.BeginTransaction()).Returns(mockTransaction.Object);
    mockSession.Setup(x => x.Dispose());
    mockTransaction.Setup(x => x.Commit());
    mockTransaction.Setup(x => x.Dispose());
    // Setups to allow for the map insertion/deletion to pass
    mockSession.Setup(x => x.Get<IndividualMap>(It.IsAny<string>())).Returns((IndividualMap)null);
    mockSession.Setup(x => x.Load<IndividualMap>(It.IsAny<string>())).Returns((IndividualMap)null);
    mockSession.Setup(x => x.Save(It.IsAny<IndividualMap>())).Returns(new object());
    mockSession.Setup(x => x.Delete(It.IsAny<IndividualMap>()));
    // Our test condition for this test: throw on attempt to save individual
    mockSession.Setup(x => x.Save(It.IsAny<Individual>()))
        .Throws(new FaultException(ForcedTestFault.Reason, ForcedTestFault.Code));
    // Test it - but be sure to back up the previous database session factory
    var originalDbSessionFactory = ServiceContext.DatabaseSessionManager;
    ServiceContext.OverrideDatabaseSessionManager(mockDatabaseSessionFactory.Object);
    try
    {
        var exception = Assert.Throws<FaultException>(() => applicationService.AddIndividual(addIndividualRequest));
        Assert.IsTrue(ForcedTestFault.Code.Name.Equals(exception.Code.Name));
    }
    catch (Exception)
    {
        // Restore the original database session factory before rethrowing
        ServiceContext.OverrideDatabaseSessionManager(originalDbSessionFactory);
        throw;
    }
    ServiceContext.OverrideDatabaseSessionManager(originalDbSessionFactory);
    ServiceContext.CommunicationManager.CloseChannel(applicationService);
