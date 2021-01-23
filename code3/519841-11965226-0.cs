    protected void gridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
     			if (e.Row.RowType == DataControlRowType.Header)
                {
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        DataControlFieldCell cell =
                            (DataControlFieldCell) e.Row.Cells[i];
    
    
                        if (cell.ContainingField.HeaderText == "fileId")
                        {
                            e.Row.Cells[i].Visible = false;
                            cell.Visible = false;
                        }
    					
    					if (cell.ContainingField.HeaderText == "fileContent")
                        {
    						e.Row.Cells[i].Visible = false;
                            cell.Visible = false;
                        }
    				}
    			}
    			
    			if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        DataControlFieldCell cell =
                            (DataControlFieldCell) e.Row.Cells[i];
    
                        if (cell.ContainingField.ToString() == "fileId")
                        {
                            cell.Visible = false;
                        }
    
                        if (cell.ContainingField.ToString() == "fileContent")
                        {
                            cell.Visible = false;
                        }
                    }
                }
    }
