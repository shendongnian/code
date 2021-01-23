    // 1. Create `SqlCommand` Mock:
    var command = MockRepository.GenerateMock<SqlCommand>();
    // 2. Create `SqlConnection` Stub:
    var connection = MockRepository.GenerateStub<SqlConnection>();
    // 3. Setup connection.CreateCommand() to return mocked command:
    connection
        .Stub(c => c.CreateCommand())
        .Return(command);
 
    // 4. Do test action:
    var dataAccess = new DataAccess();
    dataAccess.ExecuteNoneQuery(connection, null, null);
    // Assert command.ExecuteNonQuery() has been called:
    command.AssertWasCalled(c => c.ExecuteNonQuery());
