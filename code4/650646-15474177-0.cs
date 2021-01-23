    public interface ICommandHandler<in TCommand, TCommandResult, TResult> 
        where TCommand : ICommand
        where TCommandResult: ICommandResult<TResult>
    {
        TCommandResult Execute( TCommand command );
    }
