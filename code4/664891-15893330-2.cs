    System.Data.DataTable dt = new System.Data.DataTable();
               foreach (Microsoft.Office.Interop.Word.Cell c in r.Cells)
                {
                    if(c.Range.Text=="Content you want to compare")
                      dt.Columns.Add(c.Range.Text);
                }
                foreach (Microsoft.Office.Interop.Word.Row row in newTable.Rows)
                {
                    System.Data.DataRow dr = dt.NewRow();
                    int i = 0;
                    foreach (Cell cell in row.Cells)
                    {
                        if (!string.IsNullOrEmpty(cell.Range.Text)&&(cell.Range.Text=="Text you want to compare with"))
                        {
                            dr[i] = cell.Range.Text; 
                        }
                    }
                    dt.Rows.Add(dr);
                    i++;
                }
