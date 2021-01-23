    using Microsoft.Office.Interop.Excel;
    private void ExcelExport()
    {
        var excel = new Application { Visible = true };
        excel.WindowState = XlWindowState.xlMaximized;
        Workbook workbook = excel.Workbooks.Add(XlSheetType.xlWorksheet);
        Worksheet sheet = workbook.Sheets[1];
        sheet.Activate();
        string s = "<html><body><table>";
        for (int i = 1; i <= 100; i++)
        {
            s += "<tr>";
            for (int f = 1; f <= 100; f++)
            {
                s += "<td>" + i.ToString() + "," + f.ToString() + "</td>";
            }
            s += "</tr>";
        }
        s += "</table></body></html>";
        System.Windows.Forms.Clipboard.SetText(s);
        sheet.Range["A1"].Select();
        sheet.PasteSpecial(Type.Missing, false, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        sheet.Range["A1"].Select();
    }
