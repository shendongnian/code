     protected void btnFetch_Click(object sender, EventArgs e)
     {
        SqlConnection con = new SqlConnection(Helper.ConStr);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select * from emptable;select * from table1";
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        gv1.DataSource = dr;
        gv1.DataBind();
        dr.NextResult();
        while (dr.Read())
        {
            Response.Write(dr[0]);
            Response.Write(dr[1]);
        }
        con.Close();
     }
