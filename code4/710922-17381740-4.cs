    public interface IEntityStateProvider
    {
        void Save(object entity);
        void Restore(object entity);
        bool HasChanges(object entity, string property);
    }
