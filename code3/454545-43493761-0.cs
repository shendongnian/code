      static void Main()
            {
                EventLog alog = new EventLog();
                alog.Log = "Application";
                alog.MachineName = ".";
                /*  ALSO: USE the USING Statement as another member suggested
                using (SqlConnection connection1 = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=syslog2;Integrated Security=True")
                {
                    
                    using (SqlCommand comm = new SqlCommand("INSERT INTO Application VALUES (@EventLog, @TimeGenerated, @EventType, @SourceName, @ComputerName, @InstanceId, @Message) ", connection1))
                    {
                        // add the code in here
                        // AND REMEMBER: connection1.Open();
    
                    }
                }*/
                SqlConnection connection1 = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=syslog2;Integrated Security=True");
                SqlDataAdapter cmd = new SqlDataAdapter();
                // Do it one line
                cmd.InsertCommand = new SqlCommand("INSERT INTO Application VALUES (@EventLog, @TimeGenerated, @EventType, @SourceName, @ComputerName, @InstanceId, @Message) ", connection1);
                // OR YOU CAN DO IN SEPARATE LINE :
                // cmd.InsertCommand.Connection = connection1;
                connection1.Open();
    
                // CREATE YOUR SQLCONNECTION ETC OUTSIDE YOUR FOREACH LOOP
                foreach (EventLogEntry entry in alog.Entries)
                {
                    cmd.InsertCommand.Parameters.Add("@EventLog", SqlDbType.VarChar).Value = alog.Log;
                    cmd.InsertCommand.Parameters.Add("@TimeGenerated", SqlDbType.DateTime).Value = entry.TimeGenerated;
                    cmd.InsertCommand.Parameters.Add("@EventType", SqlDbType.VarChar).Value = entry.EntryType;
                    cmd.InsertCommand.Parameters.Add("@SourceName", SqlDbType.VarChar).Value = entry.Source;
                    cmd.InsertCommand.Parameters.Add("@ComputerName", SqlDbType.VarChar).Value = entry.MachineName;
                    cmd.InsertCommand.Parameters.Add("@InstanceId", SqlDbType.VarChar).Value = entry.InstanceId;
                    cmd.InsertCommand.Parameters.Add("@Message", SqlDbType.VarChar).Value = entry.Message;
                    int rowsAffected = cmd.InsertCommand.ExecuteNonQuery();
                }
                connection1.Close(); // AND CLOSE IT ONCE, AFTER THE LOOP
            }
