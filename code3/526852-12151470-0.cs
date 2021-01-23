    using System;
    using System.Collections.Generic;
    using System.Text;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelFun01
    {
        class Program
        {
            static void Main(string[] args)
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWb = xlApp.Workbooks.Open(@"C:\stackoverflow.xlsx");
                Excel.Worksheet xlWs = (Excel.Worksheet)xlWb.Sheets[1]; // Sheet1
                Excel.Worksheet xlWsNew = (Excel.Worksheet)xlWb.Sheets.Add();
    
    
                // find the data range
                Excel.Range dataRange = getDataRange(ref xlWs);
                
                // start by creating the PivotCache - this tells Excel that there is a data connection
                // to data inside the workbook (could be used to get external data, too)
                Excel.PivotCache pc = xlWb.PivotCaches().Create(Excel.XlPivotTableSourceType.xlDatabase
                                                                ,dataRange
                                                                ,Excel.XlPivotTableVersionList.xlPivotTableVersion14);
                
                // create the pivot table and set the destination to the new sheet at A1
                Excel.PivotTable pt = pc.CreatePivotTable(xlWsNew.Range["A1"]);
                
                // get the PivotField "Same" for easy referencing
                Excel.PivotField pf = (Excel.PivotField)pt.PivotFields("Same");
    
                // first add the count
                pt.AddDataField(pf, "Count of Same", Excel.XlConsolidationFunction.xlCount);
    
                // now add the row with the same field
                pf.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                pf.Position = 1;
    
                // behold!!!
                xlWsNew.Select();
                xlApp.Visible = true;
            }
    
            private static Excel.Range getDataRange(ref Excel.Worksheet xlWs)
            {
                Excel.Range rng = xlWs.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
                Excel.Range dataRange = xlWs.Range["A1", rng.Address];
                return dataRange;
            }
        }
    }
