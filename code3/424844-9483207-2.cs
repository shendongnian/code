    public interface ICommandInvoker
    {
        void Execute(ICommand command);
        TResult Execute<TResult>(ICommand<TResult> command);
    }
