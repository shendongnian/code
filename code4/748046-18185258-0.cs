    public static double SingleSimilarity(double x, double y)
    {
        return (10.0 - Math.Abs(x - y)) * 10.0;
    }
    public static double Similarity(Tuple<double, double, double> user, Tuple<double, double, double> movie)
    {
        return (SingleSimilarity(user.Item1, movie.Item1) + SingleSimilarity(user.Item2, movie.Item2) + SingleSimilarity(user.Item3, movie.Item3)) / 3.0;
    }
