    //save resource to disk
    string strPathToResource = @"c:\UTReportTemplate.xls";
    using (FileStream cFileStream = new FileStream(strPathToResource, FileMode.Create))
     {
                cFileStream.Write(Resources.UTReportTemplate, 0, Resources.template.Length);
     }
    //open workbook
    Excel.Application xlApp = new Excel.Application();
    xlWorkBook = xlApp.Workbooks.Open(strPathToResource);
    if (xlWorkBook  == null)
    {
       MessageBox.Show("Error: Unable to open Excel file.");
       return;
    }
    xlApp.Visible = false;
