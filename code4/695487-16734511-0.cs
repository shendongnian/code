    foreach (var item in results)
                    {
                        Datatable dt = new DataTable();
                        DataRow dr = dt.NewRow();
                        dr["Col1"] = item.Col1;
                        dr["Col2"] = item.Col2;
                        dt.Rows.Add(dr);
                    }
