    protected void btnGetHeader_Click(object sender, EventArgs e)
    {
        foreach (TableCell headerCell in GridView1.HeaderRow.Cells)
        {
            // or access Controls with index 
            //     headerCell.Controls[INDEX]
            Label lblHeader = headerCell.FindControl("headerLabel1") as Label;
            if (lblHeader != null)
                Debug.WriteLine("lblHeader: " + lblHeader.Text);
        }
    }
