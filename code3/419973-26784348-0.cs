    public void openExcelTemplateFromResources ()
    {
        string excelTemplateFromResources = System.IO.Path.GetTempFileName(); 
        System.IO.File.WriteAllBytes(excelTemplateFromResources,Properties.Resources.excelResource); //in your case Properties.Resources.gradesheet
        Excel.Application excelApplication = new Excel.Application();
        Excel._Workbook excelWorkbook;
        excelWorkbook = excelApplication.Workbooks.Open(excelTemplateFromResources)
     
        excelApplication.Visible = true;
    }
