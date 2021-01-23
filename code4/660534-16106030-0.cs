        protected void SearchLogsGridRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e != null)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (logDescriptionIndex == null)
                    {
                        int index = 0;
                        foreach (TableCell cell in e.Row.Cells)
                        {
                            if (cell.Controls[0] != null)
                            {
                                if (String.Equals(((LinkButton)(cell.Controls[0])).Text.Trim(), UIConstants.LogDescriptionHeader))
                                {
                                    logDescriptionIndex = index;
                                }
                            }
                            index++;
                        }
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (logDescriptionIndex != null)
                    {
                        //  Replace white spaces with HTML space.
                        //  This is to handle multiple white spaces between two characters
                        e.Row.Cells[(int)logDescriptionIndex].Text = e.Row.Cells[(int)logDescriptionIndex].Text.Replace(" ", "&nbsp;");
                    }
                }
            }
        
        }
