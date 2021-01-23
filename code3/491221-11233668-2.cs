    bool successCheckPoint = false;
    bool failureCheckPoint = false;
    foreach (var row in auditRows)
    {
        if (row.Text.Contains(sCurrentTime) ||
            row.Text.Contains(sLenientTime) ||
            row.Text.Contains(sLenientTime2))
        {
            if (row.Text.Contains("Web User Login Success"))
            {
                successCheckPoint = true;
                break;
            }
            else if (row.Text.Contains("Web User Login Failure"))
            {
                failureCheckPoint = true;
                break;
            }
        }                                
    }
