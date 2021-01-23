        public void populate()
        {
           DatabaseConnection connection = new DatabaseConnection();
           try{
           connection.Connection().Open();
           OleDbCommand cmd = new OleDbCommand;
           cmd.Connection = connection.Connection();
           cmd.ComandText = "Select score from Info"
           OleDbDataReader reader = cmd.ExecuteReader();
        
               while (reader.Read())
               {   
                    comboBox1.Items.Add(reader[0].ToString());
               }
            }
           catch(SqlException e){
                 
             
          }
          finaly{
            connection.Connection().Close();
          }
    }
