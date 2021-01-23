    MySql.Data.MySqlClient.MySqlCommand msc = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `phpbb_topics` ");
    
    MySql.Data.MySqlClient.MySqlDataReader read = msqlCommand.ExecuteReader();
    
    if(read != null)
    {
    //Sample output
    while (read.Read())
            {
                int TopicID = Convert.ToInt32(read["Topic_ID"]);
                string TopicName = Convert.ToString(read["Topic_Name"]);
                Console.WriteLine(TopicID.ToString() + " : " + TopicName);
            }
    
    }
