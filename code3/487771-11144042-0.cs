    private List<IType> items = new List<IType>();
	
	private TType GetItem<TType>(int index)
		where TType : IType
	{
		return (TType)items[index];
	}
	
	public ICollection<IType> Items
	{
		get
		{
			return this.items;
		}
	}
