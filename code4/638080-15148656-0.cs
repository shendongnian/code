    Class BusLogic
    {
     public List<string> ListboxItems = new List<string>();
     public void PopulateListBoxItems()
     {
            OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\redgabanan\Desktop\Gabanan_Red_dbaseCon\Red_Database.accdb");
            connection.Open();
            OleDbDataReader reader = null;
            OleDbCommand command = new OleDbCommand("SELECT * from  Users WHERE LastName='"+textBox8.Text+"'", connection);
            reader = command.ExecuteReader();
            listBox1.Items.Clear();
    
            while (reader.Read())
            {
                ListboxItems.Add(reader[1].ToString()+","+reader[2].ToString());
            }    
            connection.Close();
     }    
    }
