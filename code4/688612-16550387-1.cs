    public IEnumerable<bool?> GetRow (int index)
    {
        return _data [index];
    }
    public IEnumerable<bool?> GetColumn (int index)
    {
        return _data.Select (row => row [index]);
    }
    public IEnumerable<bool?> GetDiagonal (bool ltr)
    {
       for (int row = 0; row < Length; row++)
           for (int col = 0; col < Length; col++)
               yield return _data [row][ltr ? col : Length - col];
    }
    public IEnumerable<IEnumerable<bool?>> GetVectors ()
    {
        yield return GetDiagonal (true);
        yield return GetDiagonal (false);
        for (var i = 0; i < Length; i++) {
            yield return GetRow (i);
            yield return GetColumn (i);
        }
    }
