    using Microsoft.Office.Interop.Excel;
    ...
    var rowCount = excelSheet.UsedRange.Rows.Count;
    var columnCount = excelSheet.UsedRange.Columns.Count;
    var range = excelSheet.Range["A1", Type.Missing];
    range = range.Resize[rowCount, columnCount];
    return (Object[,])range.Value2;
