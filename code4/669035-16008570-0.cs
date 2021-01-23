    private StringBuilder DataGridtoHTML(DataGridView dg)
    {
      StringBuilder strB = new StringBuilder();
      //create html & table
      strB.AppendLine("<html><body><center><" + 
                    "table border='1' cellpadding='0' cellspacing='0'>");
      strB.AppendLine("<tr>");
      //cteate table header
      for (int i = 0; i < dg.Columns.Count; i++)
      {
         strB.AppendLine("<td align='center' valign='middle'>" + 
                        dg.Columns[i].HeaderText + "</td>");
       }
      //create table body
      strB.AppendLine("<tr>");
      for (int i = 0; i < dg.Rows.Count; i++)
      {
        strB.AppendLine("<tr>");
        foreach (DataGridViewCell dgvc in dg.Rows[i].Cells)
        {
            strB.AppendLine("<td align='center' valign='middle'>" + 
                            dgvc.Value.ToString() + "</td>");
        }
        strB.AppendLine("</tr>");
    }
    //table footer & end of html file
    strB.AppendLine("</table></center></body></html>");
    return strB;} 
