    String vSQL = "SELECT * FROM eits_visitor WHERE ip = '" + oUser.usrIP + "'";
    DataTable dtCurrent = SQLCon.GetDataTableFromSQL(vSQL, oHelper.cfgConnection);
     
    if (dtCurrent != null && dtCurrent.Rows.Count > 0) {
        // Check if IP is registered today
        vSQL = "SELECT TOP(1)* FROM eits_log WHERE visitor_ip = '" + oUser.usrIP + "' ORDER BY date DESC;";
        dtCurrent = SQLCon.GetDataTableFromSQL(vSQL, oHelper.cfgConnection);
    
        // Next line is where the exception is thrown:
        if (SQLCon.DateFromString(dtCurrent.Rows[0]["date"].ToString()).DayOfYear != DateTime.Now.DayOfYear) {
            // do stuff
        }
    }
