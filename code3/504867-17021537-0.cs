    [Test]
    public void WriteSpeedTest()
    {
        var excelApp = new Application();
        var workbook = excelApp.Workbooks.Add();
        var sheet = (Worksheet) workbook.Worksheets[1];
        var stopwatch = Stopwatch.StartNew();
        Write100Times(sheet);
        Console.WriteLine("Write100Times(sheet); took: " + stopwatch.ElapsedMilliseconds + " ms");
        stopwatch.Restart();
        Write100ValuesOneTime(sheet);
        Console.WriteLine("Write100ValuesOneTime(sheet); took: " + stopwatch.ElapsedMilliseconds + " ms");
        workbook.SaveAs(Path.Combine(@"C:\TEMP", "Test"));
        workbook.Close(false);
        Marshal.FinalReleaseComObject(excelApp);
    }
    private static void Write100ValuesOneTime(Worksheet sheet)
    {
        string[,] strings = new string[100,1];
        var array = Enumerable.Range(1, 100).ToArray();
        for (var index = 0; index < array.Length; index++)
        {
            strings[index, 0] = array[index].ToString();
        }
        sheet.Range["B1", "B100"].set_Value(null, strings);
    }
    private static void Write100Times(Worksheet sheet)
    {
        for (int i = 1; i < 101; i++)
        {
            sheet.Cells[i, 1].Value = i.ToString();
        }
    }
