    public interface IModelCollection<T, TModel, TIdentifier> 
           where T : IPersistedModel<TModel, TIdentifier>
    {
        IEnumerable<TModel> ReadCollection(TIdentifier identifier);
    }
