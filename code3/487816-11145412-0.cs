    if (dt.Rows.Count != 0){
        if (dt.Rows[0]["ReportID"].ToString().Length > 40)
        {
            string ReportID = dt.Rows[0]["ReportID"].ToString().Substring(0, 36);
            string ReportIDNumtwo = dt.Rows[0]["ReportID"].ToString().Substring(36, 36);
            MyGlobals1.versionDisplayTesting = ReportID;
            MyGlobals1.secondversionDisplayTesting = ReportIDNumtwo;
            return ReportID;
        }
        else if (dt.Rows[0]["ReportID"].ToString().Length < 39){
            string ReportID = dt.Rows[0]["ReportID"].ToString();
            MyGlobals1.versionDisplayTesting = ReportID;
            return ReportID;
        }
    }
    // If gets into if statement, but does not match inner conditional statements, it will end up here, if it were an else statement, return null will not get called, and a return will not be done
    return null;
