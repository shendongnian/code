    protected void generateExcelSheet_click(object sender, EventArgs e)
    {
        // Create Excel Sheet
        var sheet = new Worksheet("Hello, world!");
        sheet.Cells[0, 0] = "Hello,";
        sheet.Cells["B1"] = "World!";
        var workbook = new Workbook();
        workbook.Add(sheet);
    
        // Save
        Response.ContentType = "application/vnd.ms-excel";
        Response.AppendHeader("Content-Disposition", "attachment; filename=MyExcelSheet.xls");
        workbook.Save(Response.OutputStream, CompressionLevel.Maximum);
    
        Response.End();
    }
