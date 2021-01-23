        public interface IDatabase<TCommand> where TCommand : IDbCommand
        {
            DataTable ExecuteReaderCommand(TCommand command);
            TCommand GetNewCommand();
        }
