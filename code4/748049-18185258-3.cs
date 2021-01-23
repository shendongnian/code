    // 3 items (Action, Drama, Cartoon) each of which contain a value for user and movie
    public static double Similarity(IEnumerable<Tuple<double, double>> list)
    {
        return list.Sum(t => SingleSimilarity(t.Item1, t.Item2)) / list.Count();
    }
