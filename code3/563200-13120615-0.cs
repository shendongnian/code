    using (var sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
    using (var cmd = sqlconn.CreateCommand())
    {
        cmd.CommandText = "SELECT * FROM tbl_serial WHERE serial = @serial";
        cmd.Parameters.AddWithValue("@serial", txtQuery.Text);
        using (var dt = new DataTable())
        using (var da = new SqlDataAdapter())
        {
            try
            {
                sqlconn.Open();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                lblStatus.Text = ex.Message;
            }
            lblStatus.Text = dt.Rows.Count > 0 ? "FOUND!" : "NOT FOUND!";
        } 
    }
