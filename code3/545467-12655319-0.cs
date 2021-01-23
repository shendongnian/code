    [STAThread]
    static void WriteToExcel()
    {
        Application xlsApplication = new Application();
        var missing = System.Type.Missing;
        Workbook xlsWorkbook = xlsApplication.Workbooks.Open(excelFilePath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
        // write data to excel
        // close up            
     }
