    Class BusLogic
    {
     public List<string> ListboxItems = new List<string>();
     public void PopulateListBoxItems(string userName)
     {
      string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\redgabanan\Desktop\Gabanan_Red_dbaseCon\Red_Database.accdb";
      using (OleDbConnection db = new OleDbConnection(connString))
      {
            connection.Open();
            OleDbDataReader reader = null;
            OleDbCommand command = new OleDbCommand("SELECT * from  Users WHERE LastName='@1'", connection);            
            command.Parameters.AddWithValue("@1", userName)
            reader = command.ExecuteReader();    
            while (reader.Read())
            {
                ListboxItems.Add(reader[1].ToString()+","+reader[2].ToString());
            }    
       }
     }    
    }
