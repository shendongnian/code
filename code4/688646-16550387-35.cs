    static bool? FindWinner (IEnumerable<bool?> vector)
    {
        try {
            return vector
                .Distinct ()
                .Single ();
        } catch (InvalidOperationException) {
            return null;
        }
    }
    static bool? FindWinner (IEnumerable<IEnumerable<bool?>> vectors)
    {
        return vectors
            .Select (FindWinner)
            .FirstOrDefault (winner => winner.HasValue);
    }
    public bool? FindWinner ()
    {
        return FindWinner (GetVectors ());
    }
