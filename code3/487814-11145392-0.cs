    if (dt.Rows.Count != 0)
    {
        ...
        else if (dt.Rows[0]["ReportID"].ToString().Length < 39)
        {
            string ReportID = dt.Rows[0]["ReportID"].ToString();
            MyGlobals1.versionDisplayTesting = ReportID;
            return ReportID;
         }
        // it's possible to get here without returning anything
    }
    else
    {
        return null;
    }
