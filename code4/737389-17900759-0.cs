    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {
        MySqlConnection connection = new MySqlConnection("connection string removed");
        connection.Open();
        try
        {
            var cmd = new MySqlCommand("SELECT * FROM subject WHERE Name LIKE '%@input%'", connection);
            cmd.Parameters.Add("@input", editbox_search.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            connection.Close();
        }
        catch (Exception e)
        {
           // log the exception
        }
