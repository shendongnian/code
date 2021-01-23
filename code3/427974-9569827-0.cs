      public class GetExcel : IHttpHandler
      {
        public void ProcessRequest(HttpContext context)
        {
          DataTable dete = DBServer.GetDataTable("select * from table");
          MemoryStream ms = GetExcel.DataSetToExcelXlsx(dete, "Sheet1");
          ms.WriteTo(context.Response.OutputStream);
          context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
          context.Response.AddHeader("Content-Disposition", "attachment;filename=EasyEditCmsGridData.xlsx");
          context.Response.StatusCode = 200;
          context.Response.End();   
        }
    
        public bool IsReusable
        {
          get
          {
            return false;
          }
        }
    
        public static MemoryStream DataSetToExcelXlsx(DataTable table, string sheetName)
        {
          MemoryStream Result = new MemoryStream();
          ExcelPackage pack = new ExcelPackage();
          ExcelWorksheet ws = pack.Workbook.Worksheets.Add(sheetName);
    
          int col = 1;
          int row = 1;
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
      }
