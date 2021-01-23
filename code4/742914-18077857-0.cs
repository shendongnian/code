    protected void grid_advertise_1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (j<=1)
       {
            myConnection c = new myConnection();
            SqlDataAdapter da = new SqlDataAdapter("select * from TblArticleWishka where ID>=0 ", c.Cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = 1;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i++;
                TableCell a = new TableCell();
                a.CssClass = "advertise_1_" + i + "";
                a.Text = (string)dr["TitleEn"];
                e.Row.Cells.Add(a);
                a.DataBind();
            }
            j++;
       }
    }`
