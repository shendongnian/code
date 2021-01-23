    interface ICommand { }
    interface IHandle<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
    class CreateUserCommand : ICommand { }
    class CreateUserHandler : IHandle<CreateUserCommand>
    {
        public void Handle(CreateUserCommand command)
        {
            Console.Write("hello");
        }
    }
    [TestMethod]
    public void build_expression()
    {
        object command = new CreateUserCommand();
        object handler = new CreateUserHandler();
        Action<object, object> dispatcher = BuildDispatcher(command.GetType());
        dispatcher(handler, command);
    }
    private static Action<object, object> BuildDispatcher(Type commandType)
    {
        var handlerType = typeof(IHandle<>).MakeGenericType(commandType);
        var handleMethod = handlerType.GetMethod("Handle");
        var param1 = Expression.Parameter(typeof(object));
        var param2 = Expression.Parameter(typeof(object));
        var handler = Expression.ConvertChecked(param1, handlerType);
        var command = Expression.ConvertChecked(param2, commandType);
        var call = Expression.Call(handler, handleMethod, command);
        var lambda = Expression.Lambda<Action<object, object>>(call, param1, param2);
        return lambda.Compile();
    }
