    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        string strSQL = "Insert INTO info (id, day1,day2) Values (@id, @day1,@day2)";
        string bag_str = WebConfigurationManager.ConnectionStrings["asgdb01ConnectionString"].ConnectionString;
        conn = new SqlConnection(bag_str);
        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = strSQL;
        cmd.Parameters.Add(new SqlParameter("@id", Int32.Parse(DropDownList1.SelectedValue)));
        cmd.Parameters.Add(new SqlParameter("@day1", TextBox1.Text));
        cmd.Parameters.Add(new SqlParameter("@day2", TextBox2.Text));
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        ....
    }
