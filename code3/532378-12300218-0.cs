    var dbCommandMock = new Mock<IDbCommand>();
    dbCommandMock.Setup(dbc => dbc.ExecuteNonQuery());
    dbConnectionMock.Setup(dbc => dbc.CreateCommand()).Returns(dbCommandMock.Object);
  
    // ...
  
    dbCommandMock.VerifyAll();
