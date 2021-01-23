    foreach (ThreadPost post in ThreadPosts)
    {
     string newMessage = Clean(post.Message);
     string oldMessage = post.Message;
     // escape ' character for prevent errors in SQL script
     // I want to pass newMessage and oldMessage as an SqlParameters to prevent unexpected changes, but how it could be done based on the code bellow???
     newMessage = newMessage.Replace("'", "''");
     oldMessage = oldMessage.Replace("'", "''");
     
    cmdInsert.Parameters["@value1"].Value = post.ID.ToString();
    cmdInsert.Parameters["@value2"].Value = DBNull.Value;
    cmdInsert.Parameters["@value3"].Value = oldMessage;
    cmdInsert.Parameters["@value4"].Value = newMessage;
     
    }
