    // Create workbook and a local variable to Cells
    IWorkbook workbook = Factory.GetWorkbook();
    IRange cells = workbook.ActiveWorksheet.Cells;
    // Build up some data to use in our validation list
    cells["A1:A5"].Value = "=ROUND(RAND()*100, 0)";
    // Create cell validation on Column B using values from other cells
    cells["B:B"].Validation.Add(SpreadsheetGear.ValidationType.List, ValidationAlertStyle.Information, ValidationOperator.Default, "=$A$1:$A$5", "");
    // Create cell validation on Column C using a static list
    cells["C:C"].Validation.Add(SpreadsheetGear.ValidationType.List, ValidationAlertStyle.Information, ValidationOperator.Default, "a,b,c", "");
