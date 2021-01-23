    var val = new Random();
    var delimitedString1To100 = string.Join(",", (int[])Enumerable.Range(1, 100).ToArray());
    for (int i = 1; i < 11; i++)
    {
        using (var rnCells = xlApp.Range["A" + i.ToString()].WithComCleanup())
        {
            rnCells.Resource.Value2 = val.Next(100);
            rnCells.Resource.Cells.Validation.Delete();
            rnCells.Resource.Cells.Validation.Add(
                Microsoft.Office.Interop.Excel.XlDVType.xlValidateList,
                Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertInformation,
                Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, delimitedString1To100, Type.Missing);
        }
    }
