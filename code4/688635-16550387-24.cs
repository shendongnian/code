    public bool? GetCell (int row, int column)
    {
        return _data [row][column];
    }
    public IEnumerable<bool?> GetRow (int index)
    {
        return _data [index];
    }
    IEnumerable<int> GetIndices ()
    {
       return Enumerable.Range (0, Length);
    }
    public IEnumerable<bool?> GetColumn (int index)
    {
        return GetIndices ()
            .Select (GetRow)
            .Select (row => row [index]);
    }
    public IEnumerable<bool?> GetDiagonal (bool ltr)
    {
        return GetIndices ()
            .Select (i => Tuple.Create (i, ltr ? i : Length - i))
            .Select (pos => GetCell (pos.Item1, pos.Item2));
    }
    public IEnumerable<IEnumerable<bool?>> GetRows ()
    {
        return GetIndices ()
            .Select (GetRow);
    }
    public IEnumerable<IEnumerable<bool?>> GetColumns ()
    {
        return GetIndices ()
            .Select (GetColumn);
    }
    public IEnumerable<IEnumerable<bool?>> GetDiagonals ()
    {
        return new [] { true, false }
            .Select (GetDiagonal);
    }
    public IEnumerable<IEnumerable<bool?>> GetVectors ()
    {
        return GetDiagonals ()
            .Concat (GetRows ())
            .Concat (GetColumns ());
    }
