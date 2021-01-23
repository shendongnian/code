    using (var excel = new ExcelPackage())
    {
        var wks = excel.Workbook.Worksheets.Add("Sheet1");
        wks.Cells[1, 1].Value = "Adding picture below:";
        var pic = wks.Drawings.AddPicture("MyPhoto", new FileInfo("image.png"));
        pic.SetPosition(2, 0, 1, 0);
        excel.SaveAs(new FileInfo("outputfile.xlsx"));
    }
