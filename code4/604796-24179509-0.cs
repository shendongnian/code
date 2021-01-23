    for (int i = 0; i < gridView.HeaderRow.Cells.Count; i++)
                {
                    if (gridView.HeaderRow.Cells[i].HasControls())
                    {
                        //when gridview is sortable, type of header is LinkButton
                        // Linkbutton is in index 0 of the control
                        if (gridView.HeaderRow.Cells[i].Controls[0] is LinkButton)
                        {
                            LinkButton headerControl = gridView.HeaderRow.Cells[i].Controls[0] as LinkButton;
                           string headerName = headerControl.Text;
                                                      
                        }
                    }
                    
                }
                
