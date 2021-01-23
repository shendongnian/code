    public class CommandHandlerResolver : ISubDependencyResolver
    {
    	private readonly IKernel kernel;
    
    	public FooResolver(IKernel kernel)
    	{
    		this.kernel = kernel;
    	}
    
    	public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
    	{
    		return (dependency.TargetType.IsGenericType &&
    			    dependency.TargetType.GetGenericTypeDefinition() == typeof (ICommandHandler<>)) &&
    			    (model.Implementation.IsGenericType == false ||
    			    model.Implementation.GetGenericTypeDefinition() != typeof (DeadlockRetryCommandHandlerDecorator<>));
    	}
    
    	public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
    	{
    		return kernel.Resolve("DeadlockRetryCommandHandlerDecorator", dependency.TargetItemType);
    	}
    }
