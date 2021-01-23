    private Dictionary<string,string> itemListDesc;
    public List<string> getAllItems()
    {
        List<string> itemList = new List<string>();
        SQLiteConnection connection = new SQLiteConnection("Data Source=HCI.db");
        connection.Open();
        SQLiteCommand cmd = new SQLiteCommand("SELECT rid, name, category, price, status, specific FROM items", connection);
        SQLiteDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                //itemList.Add(reader.GetString(reader.GetInt64(rid)));
                itemList.Add(reader.GetString(reader.GetOrdinal("name")));
                itemList.Add(reader.GetString(reader.GetOrdinal("category")));
                itemList.Add(reader.GetString(reader.GetOrdinal("price")));
                itemList.Add(reader.GetString(reader.GetOrdinal("status")));
                itemList.Add(reader.GetString(reader.GetOrdinal("specific")));
                itemListDesc.Add(new Dictionary(reader.GetString(reader.GetOrdinal("name")),reader.GetString(reader.GetOrdinal("desc")));
               
            }
        }
        connection.Close();
        return itemList;
    }
    private string GetDescription(string name){
      //get description code here
    }
