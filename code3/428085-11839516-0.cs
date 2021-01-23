    class EPPlus
    {
        FileInfo newFile;
        FileInfo templateFile;
        DataSet _ds;
        ExcelPackage xlPackage;
        public string _ErrorMessage;
    
    public EPPlus(string filePath, string templateFilePath)
        {
            newFile = new FileInfo(@filePath);
            templateFile = new FileInfo(@templateFilePath);
    
            _ds = GetDataTables(); /* DataTables */
    
            _ErrorMessage = string.Empty;
    
            CreateFileWithTemplate();
    
        }
    
    private bool CreateFileWithTemplate()
        {
            try
            {
                _ErrorMessage = string.Empty;
    
                using (xlPackage = new ExcelPackage(newFile, templateFile))
                {
                    int i = 1;
                    foreach (DataTable dt in _ds.Tables)
                    {
                        AddSheetWithTemplate(xlPackage, dt, i);
                        i++;
                    }
    
    
    
                    ///* Set title, Author.. */
                    //xlPackage.Workbook.Properties.Title = "Title: Office Open XML Sample";
                    //xlPackage.Workbook.Properties.Author = "Author: Muhammad Mubashir.";
                    ////xlPackage.Workbook.Properties.SetCustomPropertyValue("EmployeeID", "1147");
                    //xlPackage.Workbook.Properties.Comments = "Sample Record Details";
                    //xlPackage.Workbook.Properties.Company = "TRG Tech.";
    
    
    
                    ///* Save */
                    xlPackage.Save();
    
                }
                return true;
            }
            catch (Exception ex)
            {
                _ErrorMessage = ex.Message.ToString();
                return false;
            }
        }
    
    /// <summary>
        /// This AddSheet method generates a .xlsx Sheet with your provided Template file, //DataTable and SheetIndex.
        /// </summary>
        public static void AddSheetWithTemplate(ExcelPackage xlApp, DataTable dt, int SheetIndex)
        {
            string _SheetName = string.Format("Sheet{0}", SheetIndex.ToString());
            ExcelWorksheet worksheet;
            /* WorkSheet */
            if (SheetIndex == 0)
            {
                worksheet = xlApp.Workbook.Worksheets[SheetIndex + 1]; // add a new worksheet to the empty workbook
            }
            else
            {
                worksheet = xlApp.Workbook.Worksheets[SheetIndex]; // add a new worksheet to the empty workbook
            }
            
            
            if (worksheet == null)
            {
                worksheet = xlApp.Workbook.Worksheets.Add(_SheetName); // add a new worksheet to the empty workbook    
            }
            else
            {
    
            }
    
            /* Load the datatable into the sheet, starting from cell A1. Print the column names on row 1 */
            worksheet.Cells["A1"].LoadFromDataTable(dt, true);
    
            
        }
    
    
    private static void AddSheet(ExcelPackage xlApp, DataTable dt, int Index, string sheetName)
        {
            string _SheetName = string.Empty;
    
            if (string.IsNullOrEmpty(sheetName) == true)
            {
                _SheetName = string.Format("Sheet{0}", Index.ToString());
            }
            else
            {
                _SheetName = sheetName;
            }
    
            /* WorkSheet */
            ExcelWorksheet worksheet = xlApp.Workbook.Worksheets[_SheetName]; // add a new worksheet to the empty workbook
            if (worksheet == null)
            {
                worksheet = xlApp.Workbook.Worksheets.Add(_SheetName); // add a new worksheet to the empty workbook    
            }
            else
            {
    
            }
    
    
    
            /* Load the datatable into the sheet, starting from cell A1. Print the column names on row 1 */
            worksheet.Cells["A1"].LoadFromDataTable(dt, true);
    
    
    
            int rowCount = dt.Rows.Count;
            int colCount = dt.Columns.Count;
    
    
    
    
    
            #region Set Column Type to Date using LINQ.
            /*
                IEnumerable<int> dateColumns = from DataColumn d in dt.Columns
                                               where d.DataType == typeof(DateTime) || d.ColumnName.Contains("Date")
                                               select d.Ordinal + 1;
    
                foreach (int dc in dateColumns)
                {
                    xlSheet.Cells[2, dc, rowCount + 1, dc].Style.Numberformat.Format = "dd/MM/yyyy";
                }
                */
    
            #endregion
            #region Set Column Type to Date using LOOP.
    
            /* Set Column Type to Date. */
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if ((dt.Columns[i].DataType).FullName == "System.DateTime" && (dt.Columns[i].DataType).Name == "DateTime")
                {
                    //worksheet.Cells[2,4] .Style.Numberformat.Format = "yyyy-mm-dd h:mm"; //OR "yyyy-mm-dd h:mm" if you want to include the time!
                    worksheet.Column(i + 1).Style.Numberformat.Format = "dd/MM/yyyy h:mm"; //OR "yyyy-mm-dd h:mm" if you want to include the time!
                    worksheet.Column(i + 1).Width = 25;
                }
            }
    
            #endregion
    
            //(from DataColumn d in dt.Columns select d.Ordinal + 1).ToList().ForEach(dc =>
            //{
            //    //background color
            //    worksheet.Cells[1, 1, 1, dc].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //    worksheet.Cells[1, 1, 1, dc].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightYellow);
    
            //    //border
            //    worksheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            //    worksheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            //    worksheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            //    worksheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            //    worksheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Top.Color.SetColor(System.Drawing.Color.LightGray);
            //    worksheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Right.Color.SetColor(System.Drawing.Color.LightGray);
            //    worksheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.LightGray);
            //    worksheet.Cells[1, dc, rowCount + 1, dc].Style.Border.Left.Color.SetColor(System.Drawing.Color.LightGray);
            //});
    
            /* Format the header: Prepare the range for the column headers */
            string cellRange = "A1:" + Convert.ToChar('A' + colCount - 1) + 1;
            using (ExcelRange rng = worksheet.Cells[cellRange])
            {
                rng.Style.Font.Bold = true;
                rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                rng.Style.Font.Color.SetColor(Color.White);
            }
    
    
    
            /* Header Footer */
            worksheet.HeaderFooter.OddHeader.CenteredText = "Header: Tinned Goods Sales";
            worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Footer: Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages); // add the page number to the footer plus the total number of pages
        }
    
    
    }// class End.
