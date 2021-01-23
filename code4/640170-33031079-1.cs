    var generated = new XLWorkbook();
    var workSheet = generated.AddWorksheet("Test");
    worksheet.Columns(2, 20).AdjustToContents();    
    worksheet.Cell(3, 2).Value = "Hello Hello Hello Hello Hello Hello Name";
    worksheet.Cell(3, 2).Style.Alignment.WrapText = true;
