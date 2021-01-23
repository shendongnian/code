    Word.InlineShape wrdInlineShape = doc.InlineShapes.AddOLEObject(classtype, Range: shapeBookMark.Range);
    Excel.Application xlApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
    xlApp.Visible = false;
    if (wrdInlineShape.OLEFormat.ProgID == classtype)
    {
        // etc...
