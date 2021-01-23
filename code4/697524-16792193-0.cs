    public interface IDataAdapter
    {
        //Your methods
    }
    internal class SqlAdapter : IDataAdapter
    {
        //This is your concrete class where a specific adapter related stuff goes
        //You can create more of these concrete types as separate classes.
    }
    internal class BaseFactory
    {
        public virtual IDataAdapter GetDataAdapter()
        {
            return null;
        }
    }
    internal class SqlFactory : BaseFactory
    {
        public override IDataAdapter GetDataAdapter()
        {
            return new SqlFactory();
        }
    }
    internal static class FactoryInitializer
    {
        public static IDataAdapter LoadAdapterOf<T>() where T : BaseFactory, new()
        {
            var factory = new T();
            return factory.GetDataAdapter();
        }
    }
