    using (var sqlconn = new SqlConnection(...)){
      try {
                sqlconn.Open();
                da.SelectCommand = cmd;
                da.Fill(dt);
      }
      catch (SqlException ex) {
                lblStatus.Text = ex.Message;
      }
    }
        if (dt.Rows.Count > 0)
        {
            lblStatus.Text = "FOUND!";
        }
        else
        {
            lblStatus.Text = "NOT FOUND!";
        }
