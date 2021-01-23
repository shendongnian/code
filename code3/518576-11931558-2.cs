    public void MapToExcelDocument(string newFileName) 
    { 
        // Declaration of variables  
        string templateName = "C:\\Template.xls"; 
        File.Copy(templateName, newFileName, true);
 
        // If you are using xls format (2003), use this connection string.             
        string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + 
                                   newFileName + ";Extended Properties=\"Excel 8.0;HDR=NO;\""; 
 
     ....
