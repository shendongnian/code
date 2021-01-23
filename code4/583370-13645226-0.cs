    Please : use this lib:
    using Microsoft.Office.Interop.Excel
    
    Please , provide password :
    WorkbookObject.Password = password;
    
    Please, Change ConnString:
    string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + s + ";Password=password;Extended Properties='Excel 8.0;HDR=YES'";
    
    Here, your answer is:
    
     if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                {
                        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Password=password;Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
                }
                else
                {
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Password=password;Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
                }
