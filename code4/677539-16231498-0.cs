	IEnumerable<T> FillBlanks<T>(IEnumerable<T> source, IEnumerable<T> collection, T blank)
	{
        // TODO: error checking
		using(var e = collection.GetEnumerator())
		{
			e.MoveNext();
			foreach(var x in source)
				if(x.Equals((T)e.Current))
				{
					yield return x;
					e.MoveNext();
				}
				else
					yield return blank;
		}
	}
    var fixed_b = FillBlanks(a, b, String.Empty);
