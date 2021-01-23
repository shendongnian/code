public void ExportToExcel(GridView gv, string filename)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename + ".xls"));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a table to contain the grid
                Table table = new Table();
                //  include the gridline settings
                table.GridLines = gv.GridLines;
                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    // PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }
                //Make Header Coloruful
                for (int j = 0; j < gv.Columns.Count; j++)
                {
                    //Apply style to Individual Cells
                    gv.HeaderRow.Cells[j].Style.Add("background-color", "yellow");
                }
                //gv.Columns.RemoveAt(12);
                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    // PrepareControlForExport(row);
                    table.Rows.Add(row);
                }
                //  add the footer row to the table
                if (gv.FooterRow != null)
                {
                    //PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i].Cells.RemoveAt(14);
                    table.Rows[i].Cells.RemoveAt(13);
                }
                //  render the table into the htmlwriter
                table.RenderControl(htw);
                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }
