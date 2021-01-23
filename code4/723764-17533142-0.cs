    DataTable finalShowsTable = new DataTable();
        
        finalShowsTable = originalFinalShowsTable.Clone();
        
        foreach (GridViewRow gvr in gvShows.Rows)
        {
            if (gvr.RowType == DataControlRowType.DataRow)
            {
                 if (((CheckBox) gvr.FindControl("cbSelect")).Checked)
                 {
                        DataRow dr= finalShowsTable.NewRow();
                         for (int i = 0; i < gvr.Cells.Count; i++)
                         {
                             dr[i] = row.Cells[i].Text;
                         }
         
                         finalShowsTable.Rows.Add(dr);
                 }
             }
        }
