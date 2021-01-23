    public void TestInsert()
        {
            var dataAccess = MockRepository.GenerateMock<IDataAccess>();
            var dbOperation = new DbOperation<string>(dataAccess);
            var sqlConnection = new SqlConnection();
            dbOperation.Insert("blah", sqlConnection, "MySP");
            dataAccess.AssertWasCalled(a => a.ExecuteNoneQuery(
                Arg.Is(sqlConnection), 
                Arg.Is("MySP"), 
                Arg<IEnumerable<SqlParameter>>.Is.Anything));
        }
