    public Tuple<bool, DateTime> GetDateTime(string x)
    {
    DateTime DT = null;
    return Tuple.Create((DateTime.TryParse(x, out DT)), DT)
    }
