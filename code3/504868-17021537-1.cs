    [Test]
    public void WriteSpeedTest()
    {
        var excelApp = new Application();
        var workbook = excelApp.Workbooks.Add();
        var sheet = (Worksheet)workbook.Worksheets[1];
        int n = 1000;
        var stopwatch = Stopwatch.StartNew();
        SeparateWrites(sheet, n);
        Console.WriteLine("SeparateWrites(sheet, " + n + "); took: " + stopwatch.ElapsedMilliseconds + " ms");
        stopwatch.Restart();
        BatchWrite(sheet, n);
        Console.WriteLine("BatchWrite(sheet, " + n + "); took: " + stopwatch.ElapsedMilliseconds + " ms");
        workbook.SaveAs(Path.Combine(@"C:\TEMP", "Test"));
        workbook.Close(false);
        Marshal.FinalReleaseComObject(excelApp);
    }
    private static void BatchWrite(Worksheet sheet, int n)
    {
        string[,] strings = new string[n, 1];
        var array = Enumerable.Range(1, n).ToArray();
        for (var index = 0; index < array.Length; index++)
        {
            strings[index, 0] = array[index].ToString();
        }
        sheet.Range["B1", "B" + n].set_Value(null, strings);
    }
    private static void SeparateWrites(Worksheet sheet, int n)
    {
        for (int i = 1; i <= n; i++)
        {
            sheet.Cells[i, 1].Value = i.ToString();
        }
    }
