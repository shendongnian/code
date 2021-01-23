	private	Dictionary<Type, List<GenericCustomerInformation>> MyLists;
	public List<GenericCustomerInformation> GetLists<T>()
	{
		return MyLists[typeof(T)];
	}
	public void AddToLists<T>(GenericCustomerInformation item)
	{
		GetLists<T>().Add(item);
	}
