    ExcelAddress _formatRangeAddress = new ExcelAddress("B3:B10,D3:D10,F3:F10,H3:H10:J3:J10");
    // fill WHITE color if previous cell or current cell is BLANK:
    // B3 is the current cell because the range _formatRangeAddress starts from B3.
    // OFFSET(B3,0,-1) returns the previous cell's value. It's excel function.
    string _statement = "IF(OR(ISBLANK(OFFSET(B3,0,-1)),ISBLANK(B3)),1,0)";
    var _cond4 = sheet.ConditionalFormatting.AddExpression(_formatRangeAddress);
    _cond4.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    _cond4.Style.Fill.BackgroundColor.Color = Color.White;
    _cond4.Formula = _statement;
    
    // fill GREEN color if value of the current cell is greater than 
    //    or equals to value of the previous cell
    _statement = "IF(OFFSET(B3,0,-1)-B3<=0,1,0)";
    var _cond1 = sheet.ConditionalFormatting.AddExpression(_formatRangeAddress);
    _cond1.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    _cond1.Style.Fill.BackgroundColor.Color = Color.Green;
    _cond1.Formula = _statement;
    
    // fill RED color if value of the current cell is less than 
    //    value of the previous cell
    _statement = "IF(OFFSET(B3,0,-1)-B3>0,1,0)";
    var _cond3 = sheet.ConditionalFormatting.AddExpression(_formatRangeAddress);
    _cond3.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
    _cond3.Style.Fill.BackgroundColor.Color = Color.Red;
    _cond3.Formula = _statement;
