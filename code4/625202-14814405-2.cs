    /// <summary>
    /// Synchronize the Time on the SQL Server with the time on the device
    /// </summary>
    public static int SyncWithSqlTime() { // pass in SQL Time and set time on device
      SYSTEMTIME st = new SYSTEMTIME();
      DateTime sqlTime = Global.NODATE;
      using (SqlCommand cmd = new SqlCommand("SELECT GETDATE() AS CurrentDateTime;", new SqlConnection(DataSettings.DatabaseConnectionString))) {
        try {
          cmd.Connection.Open();
          SqlDataReader r = cmd.ExecuteReader();
          while (r.Read()) {
            if (!r.IsDBNull(0)) {
              sqlTime = (DateTime)r[0];
            }
          }
        } catch (Exception) {
          return -1;
        }
      }
      if (sqlTime != Global.NODATE) {
        st.FromDateTime(sqlTime); // Convert to SYSTEMTIME
        if (SetLocalTime(ref st)) { //Call Win32 API to set time
          return 1;
        }
      }
      return 0;
    }
