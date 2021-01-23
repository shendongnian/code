    IDbConnection connectionMock = MockRepository.GenerateMock<IDateTimeProvider>(IDbConnection);
    
    // initialize mock object and your class here
    yourClassInstance.GetRecords(connectionMock, yourProcedureName);
    dateTimeProviderMock.AssertWasCalled(connection => connection.Open());
