    var column = reader.GetOrdinal("Analytics");
    if (!myReader.IsBDNull(column))
    {
        Analytics.Checked = myReader.GetBoolean(column);
    }
