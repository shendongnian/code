    public interface IBaseFilterable { }
    public interface IFilterable : IBaseFilterable { }
    public interface ISemiFilterable : IBaseFilterable { }
    
    public interface IJobHelper
    {
        List<T> FilterwithinOrg<T>(IEnumerable<T> entities)
            where T : IBaseFilterable
    }
