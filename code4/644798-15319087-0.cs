        string sVal = e.Row.Cells[2].Text;
        if (sVal.Contains("Field Name"))
        {
            // update cell[4] of previous row with button click event
            e.Row.Cells[2].BackColor = System.Drawing.Color.WhiteSmoke;
            e.Row.Cells[2].Font.Bold = true;
            e.Row.Cells[3].BackColor = System.Drawing.Color.WhiteSmoke;
            e.Row.Cells[3].Font.Bold = true;
            e.Row.Cells[4].BackColor = System.Drawing.Color.WhiteSmoke;
            e.Row.Cells[4].Font.Bold = true;
        }
    }
