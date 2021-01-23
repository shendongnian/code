    public void SomeStuff<T>(T entity) where T : class, IEntityPOCO
    {
        entity.Id = Guid.NewGuid(); // Works like a charm.
            
        // _processors is a List<IProcessEntities>
        var processors = _processors.Where(p => p.CanProcess(entity));
        foreach (var processor in processors)
            processor.Process(entity);
    }
    public interface IProcessEntities
    {
        bool CanProcess<T>(T entity) where T : class, IEntityPOCO;
        void Process<T>(T entity) where T : class, IEntityPOCO;
    }
    public class LastChangedProcessor : IProcessEntities
    {
        public bool CanProcess<T>(T entity) where T : class, IEntityPOCO
        {
            return typeof(IHasLastChange).IsAssignableFrom(typeof(T));
        }
        public void Process<T>(T entity) where T : class, IEntityPOCO
        {
            var lastChangeEntity = entity as IHasLastChange;
            if (lastChangeEntity != null) lastChangeEntity.LastChange = DateTime.Now;
        }
    }
