    //Because the topicNames are seperated by a semicolon, I would have to split it using the split()
    string[] splittedTopicNames = topicNames.Split(';');
    // close the connection 
    myCommand.Connection.Close();
    return Convert.ToString(splittedTopicNames);
