    private static IEnumerable<IItemChange<T>> GetChanges<T>() where T : MyBase { ... }
    public static IEnumerable<IItemChange<MyBase>> GetChangeHistory(int numberOfChanges)
    {
    	IEnumerable<IItemChange<MyBase>> obj1Changes = GetChanges<Object1>();
    	IEnumerable<IItemChange<MyBase>> obj2Changes = GetChanges<Object2>();
    	return obj1Changes.Concat(obj2Changes).OrderByDescending(r => r.When).Take(numberOfChanges);
    }
