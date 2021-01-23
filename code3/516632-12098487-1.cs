    foreach (GridViewRow r in gv.Rows)
                {
                    if (r.RowType == DataControlRowType.DataRow)
                    {
                        TableCell editCell = r.Cells[0];
                        if (editCell.Controls.Count > 0)
                        {
                            LinkButton editControl = editCell.Controls[0] as LinkButton;
                            // control[1] is a literal space
                            LinkButton selectControl = editCell.Controls[2] as LinkButton;
                            editControl.Text = "New Edit Label Text";
                            //Ensure "Select" control, not "Cancel" control 
                            selectControl.Text = selectControl.Text == "Select" ? "New Select Label Text" : selectControl.Text;
                        }
                    }
                }
