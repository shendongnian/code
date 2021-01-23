    var oldDisplayAlertsValue = Application.DisplayAlerts;
    Application.DisplayAlerts = false;
    try
    {
        outputExcelWorkBook.Close(false, Missing.Value, Missing.Value);
    }
    finally
    {
        Application.DisplayAlerts = oldDisplayAlertsValue;
    }
