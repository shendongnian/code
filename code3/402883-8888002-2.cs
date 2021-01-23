    public IEnumerable<Pet> speciesChecker ()
    {
        var groups = _pets.GroupBy (p => p.Species);
        foreach (var grp in _pets.GroupBy (p => p.Species))
        using (var e = grp.GetEnumerator ()) {
            if (!e.MoveNext ())
                continue;
            var first = e.Current;
            if (e.MoveNext ())
                continue;
            yield return first;
        }
    }
