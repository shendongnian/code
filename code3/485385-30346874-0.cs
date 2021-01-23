    foreach (GridViewRow row in GridView1.Rows)
    {
      row.BackColor = Color.White;
      foreach (TableCell cell in row.Cells)
      {
        cell.CssClass = "textmode";
        for (int i = 0; i < cell.Controls.Count; i++)
        {
          Control ctr = cell.Controls[i];
          if (ctr is TextBox)
            cell.Controls.Remove(ctr);
          else if (ctr is DropDownList)
            cell.Controls.Remove(ctr);
          else if (ctr is Label)
            {
              if (ctr.ClientID.Contains("lblrow"))
                cell.Controls.Remove(ctr);
            }
        }
      }
    }
