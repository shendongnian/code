    Dictionary<int?, int?> m = new Dictionary<int?, int?>();
    for (IEnumerator<KeyValuePair<int?, int?>> it = m.GetEnumerator(); it.MoveNext();)
    {
    	Console.Write(it.Current.Key);
    	Console.Write(it.Current.Value);
    }
