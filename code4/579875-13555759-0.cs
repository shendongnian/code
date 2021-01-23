    /// <summary>
    /// Parses a date string and returns
    /// a DateTime if it is a valid date,
    /// if not returns DBNull.Value
    /// </summary>
    /// <param name="date">Date string</param>
    /// <returns>DateTime or DBNull.Value</returns>
    public static object CreateDBDateTime(string date)
    {
        DateTime result;
        if (DateTime.TryParse(date, out result))
        {
            return result;
        }
        return DBNull.Value;
    }
