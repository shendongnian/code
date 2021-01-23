	IEnumerator enumerator = myCollection.GetEnumerator();
	try
	{
	   while (enumerator.MoveNext())
	   {
		   object current = enumerator.Current;
		   Console.WriteLine(current);
	   }
	}
	finally
	{
	   IDisposable e = enumerator as IDisposable;
	   if (e != null)
	   {
		   e.Dispose();
	   }
	}
	
