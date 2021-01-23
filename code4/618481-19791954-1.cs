    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var data_item = e.Row.DataItem; // Can use "as <type>;" if you know the type.
            if (data_item != null)
            {
                for (int i = 2; i <= 3; i++)
                {
                    var cell_content = new Label();
                    e.Row.Cells[i].Controls.Add(cell_content);
                    cell_content.Text = data_item[i];
                    if (data_item[i].Contains("monkey"))
                    {
                        cell_content.Attributes.Add("class", "monkey bold");
                    }
                    else
                    {
                        cell_content.Attributes.Add("class", "nomonkey bold");
                    }
                }
            }
