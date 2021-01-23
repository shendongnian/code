    public static IEnumerable<Match> ToEnumerable(this MatchCollection mc)
    {
        if (mc != null) {
            foreach (Match m in mc)
                yield return m;
        }
    }
