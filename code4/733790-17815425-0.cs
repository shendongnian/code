    using SpreadsheetGear;
    using SpreadsheetGear.Shapes;
    
    // Open workbook containing the CheckBox
    IWorkbook workbook = Factory.GetWorkbook("CheckBox.xls");
    // Assume CheckBox is in Sheet1
    IWorksheet worksheet = workbook.Worksheets["Sheet1"];
    // CheckBoxes reside within a Shape, so access the shape
    Shapes.IShape shape = worksheet.Shapes["Check Box 1"];
    // Access the CheckBox directly
    Shapes.IControlFormat checkbox = shape.ControlFormat;
    
    // A checkbox’s IControlFormat.Value will be set to 0 if it is unchecked, 
    // 1 if it is checked, and 2 if it is in an "indeterminate" state.  
    checkbox.Value = 1;
    
    // Assume CheckBox is linked to cell A1 in this worksheet
    worksheet.Cells["A1"].Value = true;
