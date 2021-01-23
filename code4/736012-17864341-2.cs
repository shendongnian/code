        string[] lines = {
            "Item1\tItem2\tItem3\tItem4",
            "ItemA\tItemB\tItemC\tItemD",
            "Item5\tItem6\tItem7\tItem8"
        };          
        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Workbook xlWb;
        Microsoft.Office.Interop.Excel.Worksheet xlWs;
        object misValue = System.Reflection.Missing.Value;
        xlApp = new Microsoft.Office.Interop.Excel.Application();
        xlWb = xlApp.Workbooks.Add(misValue);
        xlWs = (Microsoft.Office.Interop.Excel.Worksheet)xlWb.Worksheets.get_Item(1);
        Microsoft.Office.Interop.Excel.Range c1 =
            (Microsoft.Office.Interop.Excel.Range)xlWs.Cells[2, 1];
        Microsoft.Office.Interop.Excel.Range c2 =
            (Microsoft.Office.Interop.Excel.Range)xlWs.Cells[2 + lines.Length, 1];
        Microsoft.Office.Interop.Excel.Range range = xlWs.get_Range(c1, c2);
            
        range.Value = lines;
            
        range.TextToColumns(range,
            Microsoft.Office.Interop.Excel.XlTextParsingType.xlDelimited,
            Microsoft.Office.Interop.Excel.XlTextQualifier.xlTextQualifierNone,
            false,
            true
        );
            
        xlApp.Visible = true;
