    DataTable yourDT = new DataTable();
    yourDT.Columns.Add("content");
    // Add your columns here
    foreach (GridViewRow row in gvParent.Rows)
    {
                string Content = row.Cells[0].Text; // If you are using databound columns
                string ContentFromLabel = ((Label)row.Cells[0].FindControl("YourLabel")).Text;// If you are using Template column
    // get more columns like this that you have added
                yourDT.Rows.Add(new object[] { Content, .... other data });
    }
