    Microsoft.Office.Interop.Excel.Range chartRange;
    chartRange = workSheet.get_Range("a1", "g7");
    foreach (Microsoft.Office.Interop.Excel.Range cell in chartRange.Cells)
    {
        cell.BorderAround2();
    }
