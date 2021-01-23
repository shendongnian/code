    /// <summary>
    /// Convert a given UTC DateTime value into its localized value from given offset
    /// </summary>
    /// <param name="column">DateTime value, such as CreatedOn, UpdatedOn etc</param>
    /// <param name="offset">-60 is DST for example</param>
    private void ConvertUTCToClientTimeZone(DateTime column, int offset)
    {
        TimeSpan offsetTimeSpan = new TimeSpan(0, offset, 0).Negate();
        DateTimeOffset newDate = new DateTimeOffset(column, offsetTimeSpan);
        column = newDate.DateTime;
    }
