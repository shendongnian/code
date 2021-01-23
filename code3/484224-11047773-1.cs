    bool isColumnEmpty = true;
    for (int i = 0; i < (gridx.Rows.Count - 1); i++)
            {
                col = gridx.Rows[i].Cells["code"].Value.ToString();
                if(gridxRows[i].Cells["many"].Value == null ||       
                   gridxRows[i].Cells["many"].Value == string.Empty)
                 {
                    col4 = gridx.Rows[i].Cells["many"].Value.ToString();
                    isColumnEmpty = false; // that means some thing is found against cell
                 }
             }
