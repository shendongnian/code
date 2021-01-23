        private double maxWidth = 0.0;
        protected void gv_YourSite_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    //iterate through each cell in the row
                    //this loop will search for the widest cell
                    if (e.Row.Cells[i].Width.Value > maxWidth)
                    {
                        maxWidth = e.Row.Cells[i].Width.Value;
                        //update the header cell to match the maxWidth found
                        gv.HeaderRow.Cells[i].Width = maxWidth;
                    }
                }
            }
        }
