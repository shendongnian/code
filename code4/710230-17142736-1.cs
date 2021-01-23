    public abstract class FactoryBase
    {
        public FactoryBase() { }
        public abstract IDatabase GetDataLayer();
    }
