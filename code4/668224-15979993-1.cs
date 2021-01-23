    List<string> topicNames = new List<string>();
    // Extract the results 
    while (myDataReader.Read())
    {
        string[] topics = myDataReader.GetValue(0).ToString().Split(';')
        topicNames.AddRange(topics);
    }
