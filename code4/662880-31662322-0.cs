        var wb = new ClosedXML.Excel.XLWorkbook();
    DataTable dt = GeDataTable();//refer documentaion
    
    wb.Worksheets.Add(dt);
    
    Response.Clear();
    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    Response.AddHeader("content-disposition", "attachment;filename=\"FileName.xlsx\"");
    
    using (var ms = new System.IO.MemoryStream()) {
        wb.SaveAs(ms);
        ms.WriteTo(Response.OutputStream);
        ms.Close();
    }
    
    Response.End();
