	IEnumerable<T> FillBlanks<T>(IEnumerable<T> source, IEnumerable<T> collection, T blank)
	{
		using(var e = collection.GetEnumerator())
		{
			bool more = e.MoveNext();
			foreach(var x in source)
				if(more && x.Equals(e.Current))
				{
					yield return x;
					more = e.MoveNext();
				}
				else
					yield return blank;
		}
	}
