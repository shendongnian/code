    protected void SortBySizeButton_Click(object sender, EventArgs e)
    {
        DataView myDataView = new DataView(GetFiles()); //GetFiles is protected DataTable that populates my DataGrid :)
        myDataView.Sort = "size " + " DESC"; // size is the SortExpression
        dgFile.DataSource = myDataView;
        dgFile.DataBind();
    }
