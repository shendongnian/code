    public static bool ParseDate(string dateString, out DateTime dateValue)
    {
        long dtLong = 0L;
        bool result = false;
        if (long.TryParse(dateString, out dtLong))
        {
            // I copied the epoch code here for simplicity
            dateValue = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(dtLong);
            result = true;
        }
        // Working for US and Timestamp formats
        else if (DateTime.TryParse(dateString, out dateValue))
            result = true;
        return result;
    }
