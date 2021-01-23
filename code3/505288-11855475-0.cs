    Image logo = Image.FromFile(path);
    ExcelPackage package = new ExcelPackage(info);
    var ws = package.Workbook.Worksheets.Add("Test Page");
    for(int a = 0; a < 5; a++)
    {
        ws.Row(a*5).Height = 39.00D;
        var picture = ws.Drawings.AddPicture(a.ToString(), logo);
        // xlMove disables the auto resizing
        picture.Placement = xlMove; //XLPlacement : xlMoveAndSize,xlMove,xlFreeFloating
        picture.SetPosition(a*5, 0, 2, 0);
    }
