    using(var connection1 = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=syslog2;Integrated Security=True")
    {
        SqlDataAdapter cmd = new SqlDataAdapter();  
        using(var insertCommand = new SqlCommand("INSERT INTO Application VALUES (@EventLog, @TimeGenerated, @EventType, @SourceName, @ComputerName, @InstanceId, @Message) ")
        {
            insertCommand.Connection = connection1;
            cmd.InsertCommand = insertCommand;
            //.....
            connection1.Open();
            // .... you don't need to close the connection explicitely
        }
    }
