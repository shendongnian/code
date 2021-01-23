        int colIndStudID = 1;
        int colIndUnitID = 2;
    
        GridView1.HeaderRow.Cells[colIndStudID].Visible = false;
        GridView1.HeaderRow.Cells[colIndUnitID].Visible = false;
        foreach (GridViewRow gv in GridView1.Rows)
        {
            gv.Cells[colIndStudID].Visible = false;
            gv.Cells[colIndUnitID].Visible = false;
        }
