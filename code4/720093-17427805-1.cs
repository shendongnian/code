    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        log.Debug("Found a datarow");
        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
            log.Debug(String.Format("Row.Cell length : {0} || maxWidth : {1}", e.Row.Cells[i].Text.Length, maxWidth));
            //iterate through each cell in the row
            //this loop will search for the widest cell
            if (e.Row.Cells[i].Text.Length > maxWidth)
            {
                maxWidth = e.Row.Cells[i].Text.Length;
                log.Debug(String.Format("maxWidth is now : {0}", maxWidth));
                //update the header cell to match the maxWidth found
                //I multiplied by 10 to give it some length
                Unit u_maxWidth = Unit.Parse((maxWidth * fontFamilyFactor).ToString());
                log.Debug(String.Format("u_maxWidth is now : {0}", u_maxWidth));
                gv.HeaderRow.Cells[i].Width = u_maxWidth;
            }
        }
    }
