    FileUpload1.SaveAs(Server.MapPath("~/FileUpload/") + path.Value);
                    Workbook book = Workbook.Load(Server.MapPath(("~/FileUpload/") + FileUpload1.FileName));
                    Worksheet sheet = book.Worksheets[0];
                    sheetCount.Value = sheet.Cells.LastRowIndex.ToString();
                    foreach (Worksheet ws in book.Worksheets)
                    {
                        if (ws.Cells.Rows.Count != 0)
                        {
                            ddlSheets.Items.Add(ws.Name.ToString());
                        }
                    }
