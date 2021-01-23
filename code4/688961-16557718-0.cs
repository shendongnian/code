    private void OutPutFileToCsv(DataTable dt, string fileName, string seperator)
            {
                StringWriter stringWriter = new StringWriter();
                Int32 iColCount = dt.Columns.Count;
                for (Int16 i = 0; i < iColCount; i++)
                {
                    stringWriter.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        if (seperator.Contains(";"))
                            stringWriter.Write(";");
                        else
                            stringWriter.Write(",");
                    }
                }
                stringWriter.Write(stringWriter.NewLine);
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            stringWriter.Write(dr[i].ToString().Trim());
                        }
                        if (i < iColCount - 1)
                        {
                            if (seperator.Contains(";"))
                                stringWriter.Write(";");
                            else
                                stringWriter.Write(",");
                        }
                    }
                    stringWriter.Write(stringWriter.NewLine);
                }
    
                Response.ClearContent();
                Response.ClearHeaders();
    
                Response.ContentType = "text/csv";
                Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", fileName));
    
                Response.ContentEncoding = Encoding.GetEncoding("iso-8859-1");
                //Response.BinaryWrite(Encoding.Unicode.GetPreamble());
    
                Response.Write(stringWriter.ToString());
                Response.End();
            }
