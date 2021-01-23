    public void HideColumnByName(GridView grid, string header)
            {
                if (grid.HeaderRow.HasControls()==true)
                {
                    for (int i = 0; i < grid.HeaderRow.Cells.Count; i++)
                    {
                        if (grid.HeaderRow.Cells[i].Text == header)
                        {
                            foreach (GridViewRow row in grid.Rows)
                            {
                                row.Cells[i].Visible = false;
                                grid.HeaderRow.Cells[i].Visible = false;
                            }
                        }
    
                    }
                }
            }
