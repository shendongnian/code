    string ReportID = null;
    if (dt.Rows.Count != 0)
    {
        if (dt.Rows[0]["ReportID"].ToString().Length > 40)
        {
        ReportID = dt.Rows[0]["ReportID"].ToString().Substring(0, 36);
        string ReportIDNumtwo = dt.Rows[0]["ReportID"].ToString().Substring(36, 36);
        MyGlobals1.versionDisplayTesting = ReportID;
        MyGlobals1.secondversionDisplayTesting = ReportIDNumtwo;
        }
        else if (dt.Rows[0]["ReportID"].ToString().Length < 39)
        {
            ReportID = dt.Rows[0]["ReportID"].ToString();
            MyGlobals1.versionDisplayTesting = ReportID;
         }
    }
    return ReportID;
