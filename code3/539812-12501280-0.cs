    private void button1_Click(object sender, RibbonControlEventArgs e)
    {
        Excel.Window window = e.Control.Context;
        MessageBox.Show("Test");
        Excel.Worksheet activeWorksheet = ((Excel.Worksheet)window.Application.ActiveSheet);
        Excel.Range firstRow = activeWorksheet.get_Range("A1");
        firstRow.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
        Excel.Range newFirstRow = activeWorksheet.get_Range("A1");
        newFirstRow.Value2 = "This text was added by using code";
    }
