    bool returnValue = pDateUntil <= pNewDateUntil.Date || pDateFrom <= pNewDateUntil.Date;
    if ((pDateUntil > pNewDateUntil.Date))
    {
        AddWarningMessage("Warning Message");
    }
    return returnValue;
