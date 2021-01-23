    public IList<Field> GetPossibleMoves(int worp)
    {
        var valid = new HashSet<Field>();
        foreach (var f in GetPossibleMoves(current.LinkNorth, worp))
        {
            valid.Add(f);
        }
        foreach (var f in GetPossibleMoves(current.LinkEast, worp))
        {
            valid.Add(f);
        }
        foreach (var f in GetPossibleMoves(current.LinkSouth, worp))
        {
            valid.Add(f);
        }
        foreach (var f in GetPossibleMoves(current.LinkWest, worp))
        {
            valid.Add(f);
        }
        return valid.ToList();
    }
    private static IEnumerable<Field> GetPossibleMoves(Field current, int worp)
    {
        if (current == null)
        {
            yield break;
        }
        yield return current;
        if (worp == 0 || current.BarricadePawn) // is that a bool?
        {
            yield break;
        } 
        foreach (var f in GetPossibleMoves(current.LinkNorth, nextWorp))
        {
            yield return f;
        }
        foreach (var f in GetPossibleMoves(current.LinkEast, nextWorp))
        {
            yield return f;
        }
        foreach (var f in GetPossibleMoves(current.LinkSouth, nextWorp))
        {
            yield return f;
        }
        foreach (var f in GetPossibleMoves(current.LinkWest, nextWorp))
        {
            yield return f;
        }
    }
