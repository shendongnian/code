    ...
	private IList<IEntity> list;
	private IList<Delegate> actions;
	public void AddAction<T>(Action<T> handle) where T : IEntity {
	    actions.Add(handle);
	}
    ...
