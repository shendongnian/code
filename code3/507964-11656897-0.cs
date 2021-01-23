    myrow = new HtmlTableRow();
    for (int j = 0; j < mytbl.Rows[i].Cells.Count - 1; j++)
    {
        mycell = new HtmlTableCell();
        mycell.InnerHtml = mytbl.Rows[i].Cells[j].InnerHtml;
        myrow.Cells.Add(mycell);
    }
    clontable.Rows.Add(myrow);
