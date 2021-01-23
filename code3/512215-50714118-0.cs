     if (gvGrid.Rows.Count>0)
            {
                gvGrid.HeaderRow.Cells[0].Visible = false;
               
                for (int i = 0; i < gvGrid.Rows.Count; i++)
                {
                    gvGrid.Rows[i].Cells[0].Visible = false;
                    
                }
            }
