    Image logo = Image.FromFile(path);
    ExcelPackage package = new ExcelPackage(info);
    var ws = package.Workbook.Worksheets.Add("Test Page");
    for(int a = 0; a < 5; a++)
    {
        ws.Row(a*5).Height = 39.00D;
        var picture = ws.Drawings.AddPicture(a.ToString(), logo);
        picture.From.Column = 0;
        picture.From.Row = a;
        picture.SetSize(120, 150);
    }
        
