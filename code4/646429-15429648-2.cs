    List<string> myItems;
    
    using (MySqlConnection conn = new MySqlConnection(_CS))
    {
        conn.Open();
        string cmd = "SELECT * FROM ordertopos LIMIT 10";
        MySqlCommand custid = new MySqlCommand(cmd, conn);
        using (MySqlDataReader rdr = custid.ExecuteReader())
        {
            myItems= new List<string>();
    
            while (rdr.Read())
           {
                myItems.Add(rdr.GetString("item_name"));
           }
        }
    }
