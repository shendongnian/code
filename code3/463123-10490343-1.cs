            protected void gvReport_RowCreated(object sender, GridViewRowEventArgs e)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[1].Visible = false; 
                    e.Row.Cells[2].Visible = false;                
                }            
            }
