    public interface ICommandHandler<in TCommand, out TResult>  
        where TCommand : ICommand
        where TResult : ICommandResult<TResult>
    {
        TResult Execute( TCommand command );
    }   
