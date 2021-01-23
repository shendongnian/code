                    protected void ExportExcel(object sender, EventArgs e)
                    {
                        DataTable dt = new DataTable("GridView_Data");
                        foreach(TableCell cell in GridView1.HeaderRow.Cells)
                        {
                            dt.Columns.Add(cell.Text);
                        }
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            dt.Rows.Add();
                            for (int i=0; i<row.Cells.Count; i++)
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                            }
                       }
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt);
 
                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=GridView.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
