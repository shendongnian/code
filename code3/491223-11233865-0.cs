    var rows = auditRows.Where(TimeIsFound);
    var successCheckPoint = rows.Any(RowContainsSuccess);
    var failureCheckPoint = rows.Any(RowContainsFailure);
    
    ...elsewhere...
    
    static bool TimeIsFound(SomeType row)
    {
        return row.Text.Contains(sCurrentTime) ||
               row.Text.Contains(sLenientTime) ||
               row.Text.Contains(sLenientTime2);
    }
    static bool RowContainsSuccess(SomeType row)
    {
        return row.Text.Contains("Web User Login Success");
    }
    static bool RowContainsFailure(SomeType row)
    {
        return row.Text.Contains("Web User Login Failure");
    }
