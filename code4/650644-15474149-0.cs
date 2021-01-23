    public interface ICommandHandler<in TCommand, ICommandResult<TResult>>
        where TCommand : ICommand
    {
        TResult Execute(TCommand command);
    }
