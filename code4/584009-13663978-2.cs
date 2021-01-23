    private TEntity Get<TEntity,TId>(IList<TEntity> list, TId id)
    {
        return list.Where(item => item.Id == id);
    }
    public Client GetClient(Guid id)
    {
        return Get(clients, id);
    }
    public State GetState(short id)
    {
        return Get(states, id);
    }
