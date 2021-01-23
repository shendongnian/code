    public bool? GetCell (int row, int column)
    {
        return _data [row][column];
    }
    public IEnumerable<bool?> GetRow (int index)
    {
        return _data [index];
    }
    public IEnumerable<bool?> GetColumn (int index)
    {
        return _data.Select (row => row [index]);
    }
    IEnumerable<int> GetIndices ()
    {
        return Enumerable.Range (0, Length);
    }
    public IEnumerable<bool?> GetDiagonal (bool ltr)
    {
        return GetIndices ()
            .Select (i => Tuple.Create (i, ltr ? i : Length - i))
            .Select (pos => GetCell (pos.Item1, pos.Item2));
    }
    public IEnumerable<IEnumerable<bool?>> GetRows ()
    {
        return GetIndices ().Select (GetRow);
    }
    public IEnumerable<IEnumerable<bool?>> GetColumns ()
    {
        return GetIndices ().Select (GetColumn);
    }
    public IEnumerable<IEnumerable<bool?>> GetVectors ()
    {
        yield return GetDiagonal (true);
        yield return GetDiagonal (false);
        foreach (var row in GetRows ())
            yield return row;
        foreach (var col in GetColumns ())
            yield return col;
    }
