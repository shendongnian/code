    private DateTime RemoveDSTFromDateTime(DateTime dateTime, TimeZoneInfo timeZoneInfo)
    {
        #region detail...
        //removes daylight savings time adjustment as defined in current year
        int _currYear = DateTime.Now.Year;
        if (!dateTime.IsDaylightSavingTime())
            return dateTime;
        var result = dateTime;
        foreach (var adjustmentRule in timeZoneInfo.GetAdjustmentRules())
        {
            if (adjustmentRule.DateStart.Year <= _currYear && adjustmentRule.DateEnd.Year >= _currYear)
            {
                result = result.Subtract(adjustmentRule.DaylightDelta);
            }
        }
        return result; 
        #endregion
    }
 
