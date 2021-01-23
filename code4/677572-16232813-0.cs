	IEnumerable<T> FillBlanks<T>(IEnumerable<T> source, IEnumerable<T> collection, T blank)
	{
        //TODO error checking
		bool more = true;
		using(var e = collection.GetEnumerator())
		{
			e.MoveNext();
			foreach(var x in source)
				if(more && x.Equals((T)e.Current))
				{
					yield return x;
					more = e.MoveNext();
				}
				else
					yield return blank;
		}
	}
