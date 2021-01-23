    string sql = "update statuses set stat = @stat, tester = @tester" +
            ", timestamp_m = getdate()" +
            " where id IN (" + IDs + ") and timestamp_m < @pageLoadTime";
    SQLConnection conn = getMeASqlConnection();
    SQLCommand cmd = new SQLCommand(sql, conn);
    cmd.Parameters.Add("@stat", System.Data.SqlDbType.NVarChar).Value = UpdaterDD.SelectedValue;
    cmd.Parameters.Add("@tester", System.Data.SqlDbType.NVarChar).Value = Session["Username"].ToString();
    // Here, pageLoadTime is a DateTime object, not a string
    cmd.Parameters.Add("@pageLoadTime", System.Data.SqlDbType.DateTime).Value = pageLoadTime;
