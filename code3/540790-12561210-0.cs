    protected void grdBCReferrals_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
            int LoopCounter;
            // Variable for starting index. Use this to make sure the tabindexes start at a higher
            // value than any other controls above the gridview. 
            // Header row indexes will be 110, 111, 112...
            // First data row will be 210, 211, 212... 
            // Second data row 310, 311, 312 .... and so on
            int tabIndexStart = 10; 
                        
            for (LoopCounter = 0; LoopCounter < e.Row.Cells.Count; LoopCounter++)
            {                
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    // Check to see if the cell contains any controls
                    if (e.Row.Cells[LoopCounter].Controls.Count > 0)
                    {
                        // Set the TabIndex. Increment RowIndex by 2 because it starts at -1
                        ((LinkButton)e.Row.Cells[LoopCounter].Controls[0]).TabIndex = short.Parse((e.Row.RowIndex + 2).ToString() + tabIndexStart++.ToString());
                    }
                }
                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // Set the TabIndex. Increment RowIndex by 2 because it starts at -1
                    e.Row.Cells[LoopCounter].TabIndex = short.Parse((e.Row.RowIndex + 2).ToString() + tabIndexStart++.ToString());
                }                
            }
        }
