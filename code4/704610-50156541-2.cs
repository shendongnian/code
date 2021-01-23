	protected void fillgrid() {
		DataSet ds = new DataSet();
		ds = obj.FillGrid();
		gvdata.DataSource = ds.Tables[0];
		gvdata.DataBind();
		hdCount.Text = ds.Tables[0].Rows.Count.ToString();
	}
