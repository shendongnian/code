    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string query = "insert into temp values(@Value)";
            cn.Open();
            cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@Value", DateTime.Parse(TextBox1.Text));
            cmd.ExecuteNonQuery();
            cn.Close();
            Response.Write("Record inserted successfully");
     }
    catch (Exception ex)
    {
         Response.Write(ex.Message);
    }
