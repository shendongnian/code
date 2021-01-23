    using Excel = Microsoft.Office.Interop.Excel;
    using Microsoft.Office.Interop.Excel;
    using System.Data;
    using System.IO;
    [HttpPost]
        public ActionResult CreateExcel(int id)
        {
            DataSet dataSet = new DataSet(); //Your Data Set
            if (dataSet.Tables.Count > 0)
            {
                System.Data.DataTable dt1 = new System.Data.DataTable();
                System.Data.DataTable dt2 = new System.Data.DataTable();
                dt1 = dataSet.Tables[0];
                dt2 = dataSet.Tables[1];
                if (dt1.Rows.Count > 1 && dt2.Rows.Count > 1)
                {
                    var excel = new Microsoft.Office.Interop.Excel.Application();
                    var workbook = excel.Workbooks.Add(true);
                    AddExcelSheet(dt1, workbook);
                    AddExcelSheet(dt2, workbook);
                    //KK-Save the excel file into server path
                    string strLocation = "~/Upload/TempExcel/";
                    string fName = "Report_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".xlsx";
                    string strPath = Path.Combine(Server.MapPath(strLocation), fName);
                    workbook.SaveAs(strPath);
                    workbook.Close();
                    //KK-Generate downloading link view page
                    System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
                    Response.ClearContent();
                    Response.Clear();
                    //Response.ContentType = "application/vnd.ms-excel";  //This is for office 2003
                    Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=YourReport.xlsx");
                    Response.TransmitFile(strPath);
                    Response.Flush();
                    Response.End();
                    //KK-Deleting the file after downloading
                    if (System.IO.File.Exists(strPath))
                        System.IO.File.Delete(strPath);
                }
            }
            return View();
        }
        /// <summary>
        /// KK-This method add new Excel Worksheet using DataTable
        /// </summary>
        /// <param name="ds"></param>
        private static void AddExcelSheet(System.Data.DataTable dt, Workbook wb)
        {
            Excel.Sheets sheets = wb.Sheets;
            Excel.Worksheet newSheet = sheets.Add();
            int iCol = 0;
            foreach (DataColumn c in dt.Columns)
            {
                iCol++;
                newSheet.Cells[1, iCol] = c.ColumnName;
                newSheet.Cells[1, iCol].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.RoyalBlue);
                newSheet.Cells[1, iCol].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                newSheet.Cells[1, iCol].Font.Bold = true;
                newSheet.Cells[1, iCol].BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);
            }
            int iRow = 0;
            foreach (DataRow r in dt.Rows)
            {
                iRow++;
                // add each row's cell data...
                iCol = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    iCol++;
                    newSheet.Cells[iRow + 1, iCol] = r[c.ColumnName];
                    newSheet.Cells[iRow + 1, iCol].BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);
                }
            }
        }
