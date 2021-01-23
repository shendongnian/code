    //C#
    string query = "Insert Into Categories (CategoryName) Values (?)";
    string query2 = "Select @@Identity";
    int ID;
    string connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|Northwind.mdb";
    using (OleDbConnection conn = new OleDbConnection(connect))
    {
      using (OleDbCommand cmd = new OleDbCommand(query, conn))
      {
        cmd.Parameters.AddWithValue("", Category.Text);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.CommandText = query2;
        ID = (int)cmd.ExecuteScalar();
      }
    }
