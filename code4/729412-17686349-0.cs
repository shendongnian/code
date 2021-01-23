    public interface IServiceContract { }
    public interface IServiceInvoker<TServiceContract>
        where TServiceContract : IServiceContract
    {
    }
