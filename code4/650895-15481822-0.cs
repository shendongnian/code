    for (int i = 0; i < dt.Rows.Count; i++) {
        row = new TableRow();
        for (int j = 0; j < dt.Columns.Count; j++)
        {
           HyperLink link = new HyperLink();
           TableCell cell = new TableCell();
           if (j == dt.Columns.Count - 1)     //This last field may hava a number
           {
              if (Convert.ToInt32(dt.Rows[i][j].ToString()) > 0)
              {
                 link.ID = "link" + i + "_" + j;
                 link.NavigateUrl = "members.aspx?showLease=" + dt.Rows[i][j].ToString();
                 link.ImageUrl = "img/document.png";
                 cell.Controls.Add(link);      // How to put this in a cell, not on page 
              }
              else
              { 
                 cell.Text = dt.Rows[i][j].ToString();
              }
           }
           row.Cells.Add(cell);
         }
         t.Rows.Add(row);
    }
