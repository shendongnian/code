        foreach (GridViewRow row in GridView1.Rows)
        {
            TextBox dtm = row.FindControl("DtmTextBox") as TextBox;
            string connStr = ConfigurationManager.ConnectionStrings["bbsConnectionString"].ConnectionString;
            using (SqlConnection Con = new SqlConnection(connStr))
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("Update tblAvailable set intqty=@intQty, curprice=@curprice where intresortid=@intresortid and dtm=@dtm and strroomtype=@strroomtype", Con);
                // cmd.Parameters.AddWithValue("@dtm", DateTime.ParseExact(dtm.Text.Trim(), "dd/M/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                cmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
    DisplyGridview();
 }
