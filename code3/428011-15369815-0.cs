             DataSet ds = null;
        if (Session["sCart"] == null)
        {
            ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Product_Code", typeof(System.Int32)));
            dt.Columns.Add(new DataColumn("Product_Name", typeof(System.String)));
            dt.Columns.Add(new DataColumn("Qty", typeof(System.Int32)));
            dt.Columns.Add(new DataColumn("Price", typeof(System.Int32)));
            dt.Columns.Add(new DataColumn("Total_Price", typeof(System.Int32)));
            ds.Tables.Add(dt);
            Session["sCart"] = ds;
        }
        else
        {
            ds = (DataSet)Session["sCart"];
        }
        DataRow row = ds.Tables[0].NewRow();
        row["Product_Code"] = lblpcode.Text;
        row["Product_Name"] = lblpname.Text;
        row["Qty"] = TextBox1.Text;
        row["Price"] = lblprice.Text;
        row["Total_Price"] = Convert.ToInt32(TextBox1.Text) * Convert.ToInt32(lblprice.Text);
        ds.Tables[0].Rows.Add(row);
        Response.Redirect("mycart.aspx");
