    protected void to_excel(object sender, EventArgs e)
        {
            string filepath = Path.Combine(Server.MapPath("~/Files"), fileupload.FileName);
            fileupload.SaveAs(filepath);
            string fname = fileupload.PostedFile.FileName;
            DataTable dt = (DataTable)ReadToEnd(filepath);
            string sFilename = fname.Substring(0, fname.IndexOf("."));
            sFilename = sFilename + ".xlsx";
            MemoryStream ms = DataTableToExcelXlsx(dt, "Sheet1");
            ms.WriteTo(HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + sFilename);
            HttpContext.Current.Response.StatusCode = 200;
            HttpContext.Current.Response.End();
        }
    public void toexcel(DataTable dt, string Filename)
        {
            MemoryStream ms = DataTableToExcelXlsx(dt, "Sheet1");
            ms.WriteTo(HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Filename);
            HttpContext.Current.Response.StatusCode = 200;
            HttpContext.Current.Response.End();
        }
        public bool IsReusable
        {
            get { return false; }
        }
        public static MemoryStream DataTableToExcelXlsx(DataTable table, string sheetName)
        {
            MemoryStream Result = new MemoryStream();
            ExcelPackage pack = new ExcelPackage();
            ExcelWorksheet ws = pack.Workbook.Worksheets.Add(sheetName);
            int col = 1;
            int row = 1;
            foreach (DataColumn column in table.Columns)
            {
                ws.Cells[row, col].Value = column.ColumnName.ToString();
                col++;
            }
            col = 1;
            row = 2;
            foreach (DataRow rw in table.Rows)
            {
                foreach (DataColumn cl in table.Columns)
                {
                    if (rw[cl.ColumnName] != DBNull.Value)
                        ws.Cells[row, col].Value = rw[cl.ColumnName].ToString();
                    col++;
                }
                row++;
                col = 1;
            }
            pack.SaveAs(Result);
            return Result;
        }
