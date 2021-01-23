    public interface ISample { }
    public abstract class Sample<T> : ISample { }
    public void Bootstrapper(Container container)
    {
        container.RegisterInitializer<ISample>(
            instance => container.InjectProperties(instance));
    }
