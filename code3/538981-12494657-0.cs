    public static Int64 TestNHSQLiteBulk(bool newDB)
    {
        int ProjectCount = 1000000;
        var factory = Database.CreateSQLiteSessionFactory(newDB);
        var classMapping = (SingleTableEntityPersister)factory.GetClassMetadata(typeof(Project));
        var generator = classMapping.IdentifierGenerator;
        Int64 objectCount = 0;
        using (var session = factory.OpenStatelessSession())
        {
            var connection = session.Connection;
            using (var transaction = session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                var command = connection.CreateCommand();
                command.CommandText = "Insert INTO Project (ProjectId, ProjectName) Values(?,?)";
                var projectIdParameter = command.CreateParameter();
                projectIdParameter.ParameterName = "ProjectId";
                projectIdParameter.DbType = System.Data.DbType.Int32;
                var projectNameParameter = command.CreateParameter();
                projectNameParameter.ParameterName = "ProjectName";
                projectNameParameter.DbType = System.Data.DbType.String;
                command.Parameters.Add(projectIdParameter);
                command.Parameters.Add(projectNameParameter);
                command.Prepare();
                for (int p = 0; p < ProjectCount; p++)
                {
                    var projectId = (long)generator.Generate(session.GetSessionImplementation(), null);
                    //using prepared command is almost 2x faster!
                    projectIdParameter.Value = projectId;
                    projectNameParameter.Value = "Project" + projectId;
                    command.ExecuteNonQuery();
                    objectCount++;
                }
                transaction.Commit();
            }
        }
        return objectCount;
    }
