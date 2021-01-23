    [ServiceKnownType("GetKnownTypes")]
    public class CommandService
    {
        [OperationContract]
        public void Execute(object command)
        {
            Type commandHandlerType = typeof(ICommandHandler<>)
                .MakeGenericType(command.GetType());
 
            dynamic commandHandler =
                Bootstrapper.GetInstance(commandHandlerType);
 
            commandHandler.Handle((dynamic)command);
        }
        public static IEnumerable<Type> GetKnownTypes(
            ICustomAttributeProvider provider)
        {
            // create and return a list of all command types 
            // dynamically using reflection that this service
            // must accept.
        }
    }
