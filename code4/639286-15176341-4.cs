    public void RebuildIndexes()
    {
        Logger.Info(i => i("Rebuilding the Full-Text indices..."));
        FullText.ClearIndices();
        FullText.PopulateIndex(LoadEntities<EntityA>());
        FullText.PopulateIndex(LoadEntities<EntityB>());
        ...
    }
    private IEnumerable<T> LoadEntities<T>()
    {
        _Session.QueryOver<T>().List();
    }
