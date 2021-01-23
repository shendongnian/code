        GridViewRow currentRow = ((GridView)sender).Rows[e.RowIndex];
        String intColumnText = currentRow.Cells[2].Text; //assuming it's the first cell
        int value;
        if (int.TryParse(intColumnText, out value))
        {
            //if you want to increment that value and override the old
    ((DataTable)((GridView)sender).DataSource).Rows[CurrentRow.RowIndex][2]=(value +1).ToString();
        } 
    }
