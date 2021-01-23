    SheetProperties sp = new SheetProperties(new PageSetupProperties());
    Worksheet ws = newWorksheetPart.Worksheet;
    ws.SheetProperties = sp;
    // Set the FitToPage property to true
    ws.SheetProperties.PageSetupProperties.FitToPage = BooleanValue.FromBoolean(true);
    DocumentFormat.OpenXml.Spreadsheet.PageSetup pgOr = new DocumentFormat.OpenXml.Spreadsheet.PageSetup();
    pgOr.Orientation = DocumentFormat.OpenXml.Spreadsheet.OrientationValues.Landscape;
    pgOr.FitToHeight = 3;
    pgOr.FitToWidth = 1;
    ws.AppendChild(pgOr);
