    if (GridView1.Rows.Count > 0)
    {
        int indexofcolumn = 0;
        foreach (DataControlField column in GridView1.Columns)
        {
            if (column.HeaderText == "CustomerID") break;
            indexofcolumn++;
        }
        Session["CustomerID"] = GridView1.Rows[0].Cells[indexofcolumn].Text;
    }
