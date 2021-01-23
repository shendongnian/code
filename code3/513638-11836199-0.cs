    public int CountOfItems
    {
        get
        {
            int count = this.someEnumerable.Count();
            Contract.Assume(count > 0);
            return count;
        }
    }
