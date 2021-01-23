    public string GetNextString()
    {
        if(StringEnumerator == null || !StringEnumerator.MoveNext())
        {
            InitializeEnumerator();
            StringEnumerator.MoveNext();
        }
        return StringEnumerator.Current;
    }
