     I solved like this
               if (myGridView.Rows.Count > 0)
                {
                    var dt = new DataTable();
                    dt.Columns.Add("Column1", typeof(string));
                    dt.Columns.Add("Column2", typeof(Int64));
                    dt.Columns.Add("Column3", typeof(string));
                    
                    foreach (GridViewRow row in gd_endYearSchool.Rows)
                    {
                        var id = row.Cells[1].Text;
             //for find textbox
              var tb1 = row.Cells[2].FindControl("tbNr") as TextBox;
                        int nrord = 0;
                        if (tb1 != null)
                        {
                            var ord = tb1.Text;
                            if (!Int64.TryParse(ord, out nrord))
                            {
                                nrord = 0;
                            }
                        }
                        var text=row.Cell[3].text;
                        dt.Rows.Add(id,nrord,text);
                    }
               
                }
