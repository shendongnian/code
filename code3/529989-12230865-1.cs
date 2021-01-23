    public static string ValidatePercentValue(decimal? percentage, decimal baseValue)
    {
        try
        {
            GetPercentValue(percentage, baseValue);
            return null;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
