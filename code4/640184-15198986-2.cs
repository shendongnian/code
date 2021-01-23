    public class YourClass{
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
   
    public List<YourClass> getAllItems()
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
            itemList.Add(new YourClass(){
          Id = reader.GetString(reader.GetInt64("Id")),
          Name = reader.GetString(reader.GetOrdinal("name")),
          Description = reader.GetString(reader.GetOrdinal("desc")),
          Price = reader.GetString(reader.GetOrdinal("price"))
    });               
        }
    }
    connection.Close();
    return itemList;
    }
    //in your selectedindexchanged event
    private void lb_itemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lb_itemList.SelectedIndex > -1)
        {
              var item = lb_itemList.SelectedItem as YouClass;
              if (item != null)
              {
                    lblDescription.Text = item.Description;
                    lblPrice.Text = item.Price
              }
        }
     }
    
