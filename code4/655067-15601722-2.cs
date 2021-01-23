    public IEnumerable<int> AllParts
    {
        get
        {
            for (Current = Head; Current != null; Current = Current.Next)
            {
                yield return Current;
            }
        }
    }
