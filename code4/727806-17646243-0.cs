    public static string getEpochSeconds()
    {
        TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
        var timestamp = t.TotalSeconds;
        return timestamp.ToString("N6");
    }
