    TaskGridView.Rows[i].Cells[j + 2].Text =     
        TaskGridView.Rows[i].Cells[j + 2].Text.Substring(0,firstInd) + 
        "<span style=\"color:salmon\">" + 
        TaskGridView.Rows[i].Cells[j + 2].Text.Substring(firstInd, length) + 
        "</span>"
