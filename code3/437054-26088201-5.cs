    /// <summary>
    ///     Truncates the database.
    /// </summary>
    public void TruncateDatabase()
    {
        Sets.ToList().ForEach(s => s.Truncate());
        SaveChanges();
    }
