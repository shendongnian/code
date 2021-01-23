    protected void Button1_Click(object sender, EventArgs e)
    {
        BoundField newCol = new BoundField();
        // This string needs to be the name of the column in your datasource
        newCol.DataField = "Grade12July2012";
        // Whatever you want the column header to say
        newCol.HeaderText = "Grade(12 July 2012)";
        GridView1.Columns.Add(newCol);
        GridView1.DataBind();
    }
