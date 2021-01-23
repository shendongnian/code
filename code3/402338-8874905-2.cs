    [Microsoft.SqlServer.Server.SqlTrigger(Name = "GetTransaction", Target = "EvnLog", Event = "FOR INSERT")]
    public static void GetTransaction()
    {
        SqlCommand command;
        SqlTriggerContext triggerContext = SqlContext.TriggerContext;
        SqlPipe pipe = SqlContext.Pipe;
        SqlDataReader reader;
        if (triggerContext.TriggerAction == TriggerAction.Insert)
        {
            using (SqlConnection connection = new SqlConnection(@"context connection=true"))
            {
                connection.Open();
                command = new SqlCommand(@"SELECT * FROM INSERTED", connection);
                reader = command.ExecuteReader();
                reader.Read();
				// get inserted value
                InsertedValue1 = (DateTime)reader[0];
                InsertedValue2 = (string)reader[9];
                reader.Close();
                try
                {
                    // try to pass parameter to windows service
					
					WindowsService param = new WindowService(InsertedValue1,InsertedValue2)
                }
                catch (Exception ex)
                {
                }
            }
