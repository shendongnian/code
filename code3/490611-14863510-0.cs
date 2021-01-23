    using Excel = Microsoft.Office.Interop.Excel;
    using VBIDE = Microsoft.Vbe.Interop;
    ...
    private static void excelAddButtonWithVBA()
    {
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlBook = xlApp.Workbooks.Open(@"PATH_TO_EXCEL_FILE");
        Excel.Worksheet wrkSheet = xlBook.Worksheets[1];
        Excel.Range range;
        try
        {
            //set range for insert cell
            range = wrkSheet.get_Range("A1:A1");
            //insert the dropdown into the cell
            Excel.Buttons xlButtons = wrkSheet.Buttons();
            Excel.Button xlButton = xlButtons.Add((double)range.Left, (double)range.Top, (double)range.Width, (double)range.Height);
            //set the name of the new button
            xlButton.Name = "btnDoSomething";
            xlButton.Text = "Click me!";
            xlButton.OnAction = "btnDoSomething_Click";
            buttonMacro(xlButton.Name, xlApp, xlBook, wrkSheet);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        xlApp.Visible = true;
    }
