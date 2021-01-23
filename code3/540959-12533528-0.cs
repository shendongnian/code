    public int ColumnCountinFailedQueue(long QueueNo)
    {
        string query = "select count(QueueNo)
                        from NS_FailedQueue
                        where queueid = @QueueNo"; 
        int queueCount = 0;
        using (SqlConnection connection = new SqlConnection("connectionString"))
        using (SqlCommand getQueueCountCommand = new SqlCommand(query, connection))
        {
            getQueueCountCommand.Parameters.AddWithValue("@QueueNo", QueueNo);
			
            connection.Open();
            queueCount = (int)getQueueCountCommand.ExecuteScalar();
        }
        return queueCount;
    }
