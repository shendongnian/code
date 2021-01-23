    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {
        MySqlConnection connection = new MySqlConnection("connection string removed");
        connection.Open();
    
        try
        {
            var cmd = new MySqlCommand("SELECT * FROM subject WHERE Name LIKE '%'+@input+'%'", connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@input", editbox_search.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlDataReader dr = cmd.ExecuteReader();
            da.Fill(dr);
            GridView1.DataSource = dr;
            GridView1.DataBind();
            connection.Close();
    
        }
        catch (Exception e)
        {
           // log the exception
        }
    }
