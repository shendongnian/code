    // marker interface, mainly used as a generic constraint
    public interface ICommand
    {
    }
    // commands that return no result, or a non-query
    public interface ICommandNoResult : ICommand
    {
       void Execute();
    }
    
    // commands that return a result, either a scalar value or record set
    public interface ICommandWithResult<TResult> : ICommand
    {
       TResult Execute();
    }
    
    // a query command that executes a record set and returns the resulting entities as an enumeration.
    public interface IQuery<TEntity> : ICommandWithResult<IEnumerable<TEntity>>
    {
        int Count();
    }
    
    // used to create commands at runtime, looking up registered commands in an IoC container or service locator
    public interface ICommandFactory
    {
       TCommand Create<TCommand>() where TCommand : ICommand;
    }
