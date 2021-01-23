    public class DbCommandToken : IDisposable
    {
        private readonly SqlTransaction _transaction;
        private readonly SqlCommand _command;
        public DbCommandToken(SqlTransaction transaction, SqlCommand command)
        {
            _transaction = transaction;
            _command = command;
        }
        public Action Success { get; set; }
        public Action Failure { get; set; }
        public Task<int> Execute()
        {
            return Task.Factory.StartNew(() => _command.ExecuteNonQuery())
                .ContinueWith(t =>
                    {
                        var rowsAffected = t.Result;
                        if (rowsAffected >= 0)
                        {
                            _transaction.Commit();
                            Success();
                        }
                        ...Handle other scenarios here...
                        return t.Result;
                    });
        }
        public void Cancel()
        {
            _transaction.Rollback();
        }
        public void Dispose()
        {
            _command.Dispose();
            _transaction.Dispose();
        }
    }
