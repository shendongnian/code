            if (GridView.Rows.Count != 0)
            {
                //Forloop for header
                for (int i = 0; i < GridView.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(GridView.HeaderRow.Cells[i].Text);
                }
                //foreach for datarow
                foreach (GridViewRow row in GridView.Rows)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        dr[GridView.HeaderRow.Cells[j].Text] = row.Cells[j].Text;
                    }
                    dt.Rows.Add(dr);
                }
                //Loop for footer
                if (GridView.FooterRow.Cells.Count != 0)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < GridView.FooterRow.Cells.Count; i++)
                    {
                        //You have to re-do the work if you did anything in databound for footer.  
                    }
                    dt.Rows.Add(dr);
                }
                dt.TableName = "tb";
            }
