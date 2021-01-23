            Microsoft.Office.Tools.Excel.Worksheet worksheet = Globals.Factory.GetVstoObject(
                Globals.MercuryAddIn.Application.ActiveWorkbook.ActiveSheet);
            Excel.Range cell = worksheet.Range["A1"];
            Microsoft.Office.Tools.Excel.NamedRange r = worksheet.Controls.AddNamedRange(cell, "HeaderCells");
            r.RefersTo = "=" + worksheet.Name + "!$A$1:$A$5";
            r.RefersTo = "=" + worksheet.Name + "!$C$1:$C$5";
