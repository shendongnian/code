    string sqlCommand = "SELECT id ,firstName, lastName,subject,grade,recordID " + 
                        "from table ORDER BY recordID";
     int prevID = -1;
     int curID = -1;
     StringBUilder res = new StringBuilder()
     SqlCommand cmd = _connection.CreateCommand();
     cmd.CommandText = sqlCommand;
     SqlDataReader reader = cmd.ExecuteReader()
     while(reader.Read()
     {
         curID = Convert.ToInt32(reader[5]);
         if(curID != prevID)
         {
             prevID = curID;
             res.AppendLine("\r\nName: " + reader[1].ToString() + " " + reader[2].ToString());
             res.Append("Details:");
         }
         res.Append(reader[3].ToString() + reader[4].ToString() + ";";
     }
     Console.WriteLine(res.ToString());
