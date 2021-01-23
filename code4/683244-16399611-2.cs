    IEnumerable<Tuple<String, IEnumerable<string>>> GuessGroups(IEnumerable<string> source, int minNameLength=0, int minGroupSize=1)
    {
    	// TODO: error checking
    	return InnerGuessGroups(new Stack<string>(source.OrderByDescending(x => x)), minNameLength, minGroupSize);
    }
    IEnumerable<Tuple<String, IEnumerable<string>>> InnerGuessGroups(Stack<string> source, int minNameLength, int minGroupSize)
    {
    	if(source.Any())
    	{
    		var tuple = ExtractTuple(GetBestGroup(source, minNameLength), source);
    		if (tuple.Item2.Count() >= minGroupSize)
    			yield return tuple;
    		foreach (var element in GuessGroups(source, minNameLength, minGroupSize))
    			yield return element;	
    	}
    }
    Tuple<String, IEnumerable<string>> ExtractTuple(string prefix, Stack<string> source)
    {
    	return Tuple.Create(prefix, PopWithPrefix(prefix, source).ToList().AsEnumerable());
    }
    IEnumerable<string> PopWithPrefix(string prefix, Stack<string> source)
    {
    	while (source.Any() && source.Peek().StartsWith(prefix))
    		yield return source.Pop();
    }
    string GetBestGroup(IEnumerable<string> source, int minNameLength)
    {
    	var s = new Stack<string>(source);
    	var counter = new DictionaryWithDefault<string, int>(0);
    	while(s.Any())
    	{
    		var g = GetCommonPrefix(s);
    		if(!string.IsNullOrEmpty(g) && g.Length >= minNameLength)
    			counter[g]++;
    		s.Pop();
    	}
    	return counter.OrderBy(c => c.Value).Last().Key;
    }
    string GetCommonPrefix(IEnumerable<string> coll)
    {
     	return (from len in Enumerable.Range(0, coll.Min(s => s.Length)).Reverse()
                let possibleMatch = coll.First().Substring(0, len)
                where coll.All(f => f.StartsWith(possibleMatch))
                select possibleMatch).FirstOrDefault();
    }
    public class DictionaryWithDefault<TKey, TValue> : Dictionary<TKey, TValue>
    {
      TValue _default;
      public TValue DefaultValue {
        get { return _default; }
        set { _default = value; }
      }
      public DictionaryWithDefault() : base() { }
      public DictionaryWithDefault(TValue defaultValue) : base() {
        _default = defaultValue;
      }
      public new TValue this[TKey key]
      {
        get { return base.ContainsKey(key) ? base[key] : _default; }
        set { base[key] = value; }
      }
    }
