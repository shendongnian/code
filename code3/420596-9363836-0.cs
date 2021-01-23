    string sql = String.Format("INSERT INTO site_list (site_name) VALUES('{0}')", myTextBox.Text);
    using(SqlConnection connection = new SqlConnection(myConnectionString))
    {
       connection.open();
       using(SqlCommand cmd = new SqlCommand(sql, connection))
       {
          cmd.ExecuteNonQuery();
       }
    }
