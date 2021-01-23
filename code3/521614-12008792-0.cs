      kernel.Bind<ILog>().ToProvider<MyProvider>();
    public object Create(IContext context)
    {
        return LogManager.GetLogger(context.Request.Target.Member.DeclaringType);
    }
