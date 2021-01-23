    public static List<string> ExcelReader( string fileLocation )
    {						
        Microsoft.Office.Interop.Excel.Application excel = new Application();
        Microsoft.Office.Interop.Excel.Workbook workBook =
            excel.Workbooks.Open(fileLocation);
        workBook.SaveAs(
            fileLocation + ".csv",
            Microsoft.Office.Interop.Excel.XlFileFormat.xlCSVWindows
        );
        workBook.Close(true);
        excel.Quit();
        List<string> valueList = null;
        using (StreamReader sr = new StreamReader(fileLocation + ".csv")) {
            string content = sr.ReadToEnd();
            valueList = new List<string>(
                content.Split(
                    new string[] {"\r\n"},
                    StringSplitOptions.RemoveEmptyEntries
                )
            );
        }
        new FileInfo(fileLocation + ".csv").Delete();
        return valueList;
    }
