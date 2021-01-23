    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        DateTime datToday = DateTime.Today();
        DateTime O1 = datToday.AddDays(0);
        DateTime O2 = datToday.AddDays(-1);
        DateTime O3 = datToday.AddDays(-4);
        string strMediaX = e.Row.Cells[2].Text;
        if (Information.IsDate(strMediaX))
        {
            DateTime MediaX = e.Row.Cells[2].Text;
            if (MediaX < O3)
            {
                e.Row.Cells[2].BackColor = Drawing.Color.OrangeRed;
                e.Row.Cells[2].ForeColor = Drawing.Color.White;
            }
            else if (MediaX < O2)
            {
                e.Row.Cells[2].BackColor = Drawing.Color.Orange;
                e.Row.Cells[2].ForeColor = Drawing.Color.White;
            }
            else if (MediaX < O1)
                e.Row.Cells[2].BackColor = Drawing.Color.Gold;
        }
        // checks the current stock of the item and if it is below 10 then it changes the colour to highlight that it needs to be ordered.
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((Label)e.Row.Cells[9].FindControl("lblCurrentStock").Text < 11)
            {
                e.Row.Cells[9].BackColor = System.Drawing.Color.OrangeRed;
                e.Row.Cells[9].ForeColor = Drawing.Color.White;
                e.Row.Cells[9].Font.Bold = true;
            }
        }
    }
