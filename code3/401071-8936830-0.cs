        protected override void WriteFile(HttpResponseBase response)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(this.workBookName);
                ws.Cells["A1"].LoadFromDataTable(this.dataTable, true);
                response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                response.AddHeader("content-disposition", "attachment;  filename=" + fileName);
                response.BinaryWrite(pck.GetAsByteArray());
            }
        }
