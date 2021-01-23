	var type = typeof(int);
	IList<object> myList = (new object[]{1, 2, 3, 4, 5}).ToList();
	var mi = typeof(Enumerable).GetMethod("Cast");
	var mRef = mi.MakeGenericMethod(type);
	object myIEnumerableOfInt = mRef.Invoke(null, new object[]{myList});
	mi = typeof(Enumerable).GetMethod("ToList");
	mRef = mi.MakeGenericMethod(type);
	IList myIListOfInt = (IList)mRef.Invoke(null, new object[]{myIEnumerableOfInt});
