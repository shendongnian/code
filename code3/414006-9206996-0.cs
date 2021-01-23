    public void CreateCSVFile(System.Data.DataTable dt, out StringWriter stw)
            {
                stw = new StringWriter();
                int iColCount = dt.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    stw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        stw.Write(",");
                    }
                }
                stw.Write(stw.NewLine);
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            stw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            stw.Write(",");
                        }
                    }
                    stw.Write(stw.NewLine);
                }
            }
