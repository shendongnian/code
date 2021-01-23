    [ServiceKnownType("GetKnownTypes")]
    public class CommandService
    {
        [OperationContract]
        public void Execute(object command)
        {
            Type commandHandlerType = typeof(ICommandHandler<>)
                .MakeGenericType(command.GetType());
 
            object commandHandler =
                Bootstrapper.GetInstance(commandHandlerType);
 
            commandHandlerType.GetMethod("Handle")
                .Invoke(commandHandler, new[] { command });
        }
        public static IEnumerable<Type> GetKnownTypes(
            ICustomAttributeProvider provider)
        {
            // create and return a list of all command types 
            // dynamically using reflection that this service
            // must accept.
        }
    }
