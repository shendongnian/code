    [Target("DatabaseLog")]
    public sealed class DatabaseLogTarget : TargetWithLayout
    {
      public DatabaseLogTarget()
      {
      }
    
      protected override void Write(AsyncLogEventInfo logEvent)
      {
        //base.Write(logEvent);
        this.SaveToDatabase(logEvent.LogEvent);
      }
    
      protected override void Write(AsyncLogEventInfo[] logEvents)
      {
        //base.Write(logEvents);
        foreach (AsyncLogEventInfo info in logEvents)
        {
          this.SaveToDatabase(info.LogEvent);
        }
      }
    
      protected override void Write(LogEventInfo logEvent)
      {
        //string logMessage = this.Layout.Render(logEvent);
        this.SaveToDatabase(logEvent);
      }
    
      private void SaveToDatabase(LogEventInfo logInfo)
      {
        if (logInfo.Properties.ContainsKey("commandText") &&
          logInfo.Properties["commandText"] != null)
        {
          //Build the new connection
          SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    
          //use the connection string if it's present
          if (logInfo.Properties.ContainsKey("connectionString") && 
            logInfo.Properties["connectionString"] != null)
            builder.ConnectionString = logInfo.Properties["connectionString"].ToString();
    
          //set the host
          if (logInfo.Properties.ContainsKey("dbHost") &&
            logInfo.Properties["dbHost"] != null)
            builder.DataSource = logInfo.Properties["dbHost"].ToString();
    
          //set the database to use
          if (logInfo.Properties.ContainsKey("dbDatabase") &&
            logInfo.Properties["dbDatabase"] != null)
            builder.InitialCatalog = logInfo.Properties["dbDatabase"].ToString();
    
          //if a user name and password are present, then we're not using integrated security
          if (logInfo.Properties.ContainsKey("dbUserName") && logInfo.Properties["dbUserName"] != null &&
            logInfo.Properties.ContainsKey("dbPassword") && logInfo.Properties["dbPassword"] != null)
          {
            builder.IntegratedSecurity = false;
            builder.UserID = logInfo.Properties["dbUserName"].ToString();
            builder.Password = logInfo.Properties["dbPassword"].ToString();
          }
          else
          {
            builder.IntegratedSecurity = true;
          }
    
          //Create the connection
          using (SqlConnection conn = new SqlConnection(builder.ToString()))
          {
            //Create the command
            using (SqlCommand com = new SqlCommand(logInfo.Properties["commandText"].ToString(), conn))
            {
              foreach (DatabaseParameterInfo dbi in logInfo.Parameters)
              {
                //Add the parameter info, using Layout.Render() to get the actual value
                com.Parameters.AddWithValue(dbi.Name, dbi.Layout.Render(logInfo));
              }
    
              //open the connection
              com.Connection.Open();
    
              //Execute the sql command
              com.ExecuteNonQuery();
            }
          }
        }
      }
    }
