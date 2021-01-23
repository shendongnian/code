    private int _loadCounter;
    private TheDomainContext _domainContext;
    private void Load<TEntity>(EntityQuery<TEntity> query,
                               Action<LoadOperation<TEntity>> callback)
    {
        BeginLoading();
        Action<LoadOperation<TEntity>> internalCallback = 
                loadOp => {
                              callback(loadOP);
                              EndLoading();
                          };
        _domainContext.Load(query, internalCallback , null);
    }
    private void BeginLoading()
    {
        _loadCounter++;
        // You could add logic to indicate the app is busy
    }
    private void EndLoading()
    {
        _loadCounter--;
        if (_loadCounter == 0)
        {
            OnLoadComplete();
        }
    }
    private void OnLoadComplete()
    {
        // TODO Everything is loaded
    }
    private void BeginLoadingTheQueries()
    {
        // Increment once here to prevent the OnLoadComplete from occurring
        // before all queries have started
        BeginLoading();
        Load(_domainContext.GetSitesQuery(), Query_Completed);
        Load(_domainContext.GetOtherQuery(), OtherQuery_Completed);
        EndLoading();
    }
