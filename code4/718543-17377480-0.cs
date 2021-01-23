    protected void Page_Load(object sender, System.EventArgs e)
    {
        
        DataTable dt = new DataTable();
        dt.Columns.Add("Shipper", typeof(string));
        dt.Columns.Add("ShipperTemp", typeof(string));
        dt.Rows.Add("CShipper1", "1");
        dt.Rows.Add("BShipper2", "2");
        dt.Rows.Add("AShipper1", "1");
        dt.Rows.Add("EShipper1", "2");
        dt.Rows.Add("DShipper4", "4");
        
        DataRow dr = dt.NewRow();
        dt.Rows.InsertAt(dr, 0);
        //creating the first row of Gridview to be editable
        GridView1.EditIndex = 0;
        //Data Sourcing and binding
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //Changing the Text for Inserting a New Record
        //((LinkButton)GridView1.Rows[0].Cells[0].Controls[0]).Text = "Insert";
      
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit)
        {
            e.Row.Cells[0].Controls.Clear(); // Comment this line if you do not want to hide Textbox from First Cell first Row
            LinkButton btn = new LinkButton();
            btn.ID = "ID";
            btn.Text = "Insert";
            e.Row.Cells[0].Controls.Add(btn);
        }
    }
