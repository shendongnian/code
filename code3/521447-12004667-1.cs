    public override int Compare(string x, string y)
    {
        if (object.ReferenceEquals(x, y))
        {
            return 0;
        }
        if (x == null)
        {
            return -1;
        }
        if (y == null)
        {
            return 1;
        }
        return this._compareInfo.Compare(x, y, this._ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
    }
