    private void getGridInfo()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("BookName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("BookQty", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("BookImg", typeof(String)));
    
            foreach (GridViewRow row in gvShoppingCart.Rows)
            {
                Image Bookimg = (Image)row.FindControl("BookImg");
                Label Booknames = (Label)row.FindControl("lblBookName");
                TextBox Bookqty = (TextBox)row.FindControl("TXTQty");
                Label TotalPrice = (Label)row.FindControl("LBLTotal");
                dr = dt.NewRow();
                dr[0] = Booknames.Text;
                dr[1] = Bookqty.Text;
                dr[2] = Bookimg.ImageUrl.ToString();
                dt.Rows.Add(dr);
            }
            Session["QtyTable"] = dt;
            Response.Redirect("Admin/Default.aspx");
        } 
