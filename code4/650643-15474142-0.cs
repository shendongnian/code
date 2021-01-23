    public interface ICommandResult<out TResult>
    {
        TResult Result { get; }
    }
    
    public interface ICommandHandler<in TCommand, TResult, TResultType>  
                                                            where TCommand : ICommand
                                                            where TResult : ICommandResult<TResultType>
    {
        TResult Execute( TCommand command );
    }
