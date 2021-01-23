	private static ConcurrentDictionary< string, SomeItemsBag > _SomeItemsBag;
	private static ConcurrentDictionary< string, SomeItemsList > _SomeItemsList;
	private static object _someItemsListLocker = new object();
	private static void GetItem(string key)
	{
		var bag = _SomeItemsBag[key];
		lock (_someItemsListLocker) {
			var list = _SomeItemsList[key];
		}
	}
