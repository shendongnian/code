    public List<Item> getAllItems()
    {
            List<Item> itemList = new List<Item>();
            SQLiteConnection connection = new SQLiteConnection("Data Source=HCI.db");
            connection.Open();
    
            SQLiteCommand cmd = new SQLiteCommand("SELECT rid, name, category, price, status, specific FROM items", connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
    
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //itemList.Add(reader.GetString(reader.GetInt64(rid)));
                    var item = new Item();
                    item.Name = reader.GetString(reader.GetOrdinal("name"));
                    item.Description = reader.GetString(reader.GetOrdinal("specific"))
                    itemList.Add(item);
                }
            }
            connection.Close();
            return itemList;
    }
