    class FakeConnectionFactory : DriverConnectionProvider
    {
        public override IDbConnection GetConnection()
        {
            return new FakeConnection(base.GetConnection());
        }
    }
    class FakeConnection : DbConnection
    {
        private IDbConnection _connection;
        public FakeConnection(IDbConnection connection)
        {
            _connection = connection;
        }
        ...
        protected override DbCommand CreateDbCommand()
        {
            return new FakeCommand(_connection.CreateCommand());
        }
    }
    class FakeCommand : DbCommand
    {
        private IDbCommand iDbCommand;
        public FakeCommand(IDbCommand iDbCommand)
        {
            this.iDbCommand = iDbCommand;
        }
        ...
        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            return EmptyDataReader();
        }
        public override int ExecuteNonQuery()
        {
            return 0;
        }
        public override object ExecuteScalar()
        {
            return 0;
        }
    }
