    public IEnumerable<string> List1 = new [] { "A", "B", "C" };
    public IEnumerable<string> List2 = new [] { "1", "2", "3" };
    public IEnumerable<string> List3 = new [] { "Z", "Y" };
    public IEnumerator<string> StringEnumerator;
    public void InitializeEnumerator()
    {
        var stringEnumerable = List1.SelectMany(x => List2.SelectMany(y => List3.Select(z => x + y + z)));
	
        StringEnumerator = stringEnumerable.GetEnumerator();
    }
    public string GetNextString()
    {
        return StringEnumerator.MoveNext() ? StringEnumerator.Current : null;
    }
