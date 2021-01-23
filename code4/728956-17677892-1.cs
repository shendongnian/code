    // Create the TableCell object
    DocumentFormat.OpenXml.Wordprocessing.TableCell tc = 
        new DocumentFormat.OpenXml.Wordprocessing.TableCell();
    // Create the TableCellProperties object
    TableCellProperties tcp = new TableCellProperties(
        new TableCellWidth { Type = TableWidthUnitValues.Auto, }
    );
    // Create the Shading object
    DocumentFormat.OpenXml.Wordprocessing.Shading shading = 
        new DocumentFormat.OpenXml.Wordprocessing.Shading() {
        Color = "auto",
        Fill = "ABCDEF",
        Val = ShadingPatternValues.Clear
    };
    // Add the Shading object to the TableCellProperties object
    tcp.Append(shading);
    // Add the TableCellProperties object to the TableCell object
    tc.Append(tcp);
