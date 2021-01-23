    public static void Export(GridView gv)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "MyExcelFile.xls"));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        using (StringWriter stringWriter = new StringWriter())
        {
            using (HtmlTextWriter tetxWriter = new HtmlTextWriter(stringWriter))
            {
                
                System.Web.UI.WebControls.Table tableControl = new Table();
                tableControl.GridLines = gv.GridLines;
                //  Add the header row to the table
                if (gv.HeaderRow != null)
                {
                    ReplaceControlForExport(gv.HeaderRow);
                    #region Dynamic Frrst Header Row
                    TableRow newRow = new TableRow();
                    TableCell cell1 = new TableHeaderCell();
                    cell1.ColumnSpan = 1; 
                    cell1.Text = "";
                    TableCell cell2 = new TableCell();
                    cell2.ColumnSpan = 2;
                    cell2.Text = "One";
                    TableCell cell3 = new TableCell();
                    cell3.ColumnSpan = 2;
                    cell3.Text = "Two";
                    TableCell cell4 = new TableCell();
                    cell4.ColumnSpan = 2;
                    cell4.Text = "Three";
                    
                    newRow.Cells.Add(cell1);
                    newRow.Cells.Add(cell2);
                    newRow.Cells.Add(cell3);
                    newRow.Cells.Add(cell4);
                    foreach (TableCell cell in newRow.Cells)
                    {
                        cell.Style[System.Web.UI.HtmlTextWriterStyle.BackgroundColor] = "Purple";
                    }
                    tableControl.Rows.Add(newRow);
                    #endregion 
                    TableRow originalHeaderRow = gv.HeaderRow;
                    foreach (TableCell cell in originalHeaderRow.Cells)
                    {
                        cell.Style[System.Web.UI.HtmlTextWriterStyle.BackgroundColor] = "Orange";
                    }
                    tableControl.Rows.Add(originalHeaderRow);
                }
                //  Add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    ReplaceControlForExport(row);
                    
                    TableRow tableRow = row;
                    foreach (TableCell cell in tableRow.Cells)
                    {
                        cell.Style[System.Web.UI.HtmlTextWriterStyle.BackgroundColor] = "Yellow";
                    }
                    tableControl.Rows.Add(row);
                }
                //  Render the table into the htmlwriter
                tableControl.RenderControl(tetxWriter);
                //  Render the htmlwriter into the response
                HttpContext.Current.Response.Write(stringWriter.ToString());
                HttpContext.Current.Response.End();
                
            }
        }
      }
     private static void ReplaceControlForExport(Control mainControlElement)
     {
        for (int i = 0; i < mainControlElement.Controls.Count; i++)
        {
            Control currentControl = mainControlElement.Controls[i];
            if (currentControl is LinkButton)
            {
                mainControlElement.Controls.Remove(currentControl);
                mainControlElement.Controls.AddAt(i, new LiteralControl((currentControl as LinkButton).Text));
            }
            else if (currentControl is ImageButton)
            {
                mainControlElement.Controls.Remove(currentControl);
                mainControlElement.Controls.AddAt(i, new LiteralControl((currentControl as ImageButton).AlternateText));
            }
            else if (currentControl is HyperLink)
            {
                mainControlElement.Controls.Remove(currentControl);
                mainControlElement.Controls.AddAt(i, new LiteralControl((currentControl as HyperLink).Text));
            }
            else if (currentControl is DropDownList)
            {
                mainControlElement.Controls.Remove(currentControl);
                mainControlElement.Controls.AddAt(i, new LiteralControl((currentControl as DropDownList).SelectedItem.Text));
            }
            else if (currentControl is CheckBox)
            {
                mainControlElement.Controls.Remove(currentControl);
                mainControlElement.Controls.AddAt(i, new LiteralControl((currentControl as CheckBox).Checked ? "True" : "False"));
            }
            //Recursive Call
            if (currentControl.HasControls())
            {
                ReplaceControlForExport(currentControl);
            }
        }
    }
