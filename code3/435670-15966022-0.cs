    ExcelPackage pck = new ExcelPackage();
    .....
    .....
    .....
    
    byte[] bfr = pck.GetAsByteArray();
    Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    Response.AppendHeader("content-disposition", "attachment; filename=ExcelFileName.xlsx");
    
    Response.OutputStream.Write(bfr, 0, bfr.Length);
    Response.Flush();
    Response.Close();
