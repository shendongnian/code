    public Tuple<bool, DateTime> GetDateTime(string x)
    {
    DateTime DT = null;
    return new Tuple<bool, DateTime>((DateTime.TryParse(x, out DT)), DT)
    }
