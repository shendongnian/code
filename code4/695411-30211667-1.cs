        using Excel = Microsoft.Office.Interop.Excel;
        private void Convert_CSV_To_Excel()
        {
            // Rename .csv To .xls
            System.IO.File.Move(@"d:\Test.csv", @"d:\Test.csv.xls");
            var _app = new Excel.Application();
            var _workbooks = _app.Workbooks;
            _workbooks.OpenText("Test.csv.xls",
                                     DataType: Excel.XlTextParsingType.xlDelimited,
                                     TextQualifier: Excel.XlTextQualifier.xlTextQualifierNone,
                                     ConsecutiveDelimiter: true,
                                     Semicolon: true);
            // Convert To Excle 97 / 2003
            _workbooks[1].SaveAs("NewTest.xls", Excel.XlFileFormat.xlExcel5);
            _workbooks.Close();
        }
