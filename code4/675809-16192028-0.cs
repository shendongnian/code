    // fileName = your file name like test.xls
    // dt = your data table
    // caption = it is caption which display on top of excel file.
     public static void Export(string fileName, DataTable dt, string Caption)
            {
    
    
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
                HttpContext.Current.Response.Charset = "windows-1254"; //ISO-8859-13 ISO-8859-9  windows-1254
    
                HttpContext.Current.Response.AddHeader(
                    "content-disposition", string.Format("attachment; filename={0}", fileName));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                string header = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\n<head>\n<title></title>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1254\" />\n<style>\n</style>\n</head>\n<body>\n";
    
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        //  Create a form to contain the grid
              
                        Table table = new Table();
                        table.GridLines = GridLines.Horizontal;
                        //table.CellSpacing = 17;                                      
    
                        if (Caption.Trim() != "")
                            table.Caption = "<span style='background-color: #FFFFFF; color: #666666; font-size: 14pt; font-weight: bold; padding: 5px 0px; height: 30px;'>" + Caption + "</span>";
    
                        TableRow row = null;
                        row = new TableRow();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            TableHeaderCell headerCell = new TableHeaderCell();
                            headerCell.Text = dt.Columns[i].ColumnName;
                            PrepareControlForExport(headerCell);
                            row.Cells.Add(headerCell);
                        }
                        table.Rows.Add(row);
                        foreach (DataRow rows in dt.Rows)
                        {
                            row = new TableRow();
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                TableCell RowCell = new TableCell();
                                RowCell.Text = rows[i].ToString();
                                PrepareControlForExport(RowCell);
                                row.Cells.Add(RowCell);
                            }
                            table.Rows.Add(row);
                        }
    
                        //  render the table into the htmlwriter
                        table.RenderControl(htw);
    
                        //  render the htmlwriter into the response
                        HttpContext.Current.Response.ContentType = "text/csv";
                        HttpContext.Current.Response.Write(header + sw.ToString());
                        HttpContext.Current.Response.End();
                      
                     }
                }
            }
    
            private static void PrepareControlForExport(Control control)
            {
                for (int i = 0; i < control.Controls.Count; i++)
                {
                    Control current = control.Controls[i];
                    if (current is LinkButton)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                    }
                    else if (current is ImageButton)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                    }
                    else if (current is HyperLink)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                    }
                    else if (current is DropDownList)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                    }
                    else if (current is CheckBox)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                    }
                    else if (current is Label)
                    {
                        control.Controls.Remove(current);
                        control.Controls.AddAt(i, new LiteralControl((current as Label).Text));
                    }
    
                    if (current.HasControls())
                    {
                        ReportExport.PrepareControlForExport(current);
                    }
                }
            }
