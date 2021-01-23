    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OfficeOpenXml.Table;
    using OfficeOpenXml.Table.PivotTable;
    using OfficeOpenXml;
    using System.IO;
    
    namespace pTable
    {
        class Program
        {
            static void Main(string[] args)
            {
                //ExcelPackage _pck = new ExcelPackage();
    
                Directory.CreateDirectory(string.Format("Test"));
                //ExcelPackage _pck = new ExcelPackage(new FileInfo("Test\\Worksheet.xlsx"));
                ExcelPackage _pck = new ExcelPackage(new FileInfo("Test\\Worksheet.xlsm"));
    
                var wsPivot1 = _pck.Workbook.Worksheets.Add("Rows-Data on columns");
                
                var ws = _pck.Workbook.Worksheets.Add("Data");
                ws.Cells["K1"].Value = "Item";
                ws.Cells["L1"].Value = "Category";
                ws.Cells["M1"].Value = "Stock";
                ws.Cells["N1"].Value = "Price";
                ws.Cells["O1"].Value = "Date for grouping";
    
                ws.Cells["K2"].Value = "Crowbar";
                ws.Cells["L2"].Value = "Hardware";
                ws.Cells["M2"].Value = 12;
                ws.Cells["N2"].Value = 85.2;
                ws.Cells["O2"].Value = new DateTime(2010, 1, 31);
    
                ws.Cells["K3"].Value = "Crowbar";
                ws.Cells["L3"].Value = "Hardware";
                ws.Cells["M3"].Value = 15;
                ws.Cells["N3"].Value = 12.2;
                ws.Cells["O3"].Value = new DateTime(2010, 2, 28);
    
                ws.Cells["K4"].Value = "Hammer";
                ws.Cells["L4"].Value = "Hardware";
                ws.Cells["M4"].Value = 550;
                ws.Cells["N4"].Value = 72.7;
                ws.Cells["O4"].Value = new DateTime(2010, 3, 31);
    
                ws.Cells["K5"].Value = "Hammer";
                ws.Cells["L5"].Value = "Hardware";
                ws.Cells["M5"].Value = 120;
                ws.Cells["N5"].Value = 11.3;
                ws.Cells["O5"].Value = new DateTime(2010, 4, 30);
    
                ws.Cells["K6"].Value = "Crowbar";
                ws.Cells["L6"].Value = "Hardware";
                ws.Cells["M6"].Value = 120;
                ws.Cells["N6"].Value = 173.2;
                ws.Cells["O6"].Value = new DateTime(2010, 5, 31);
    
                ws.Cells["K7"].Value = "Hammer";
                ws.Cells["L7"].Value = "Hardware";
                ws.Cells["M7"].Value = 1;
                ws.Cells["N7"].Value = 4.2;
                ws.Cells["O7"].Value = new DateTime(2010, 6, 30);
    
                ws.Cells["K8"].Value = "Saw";
                ws.Cells["L8"].Value = "Hardware";
                ws.Cells["M8"].Value = 4;
                ws.Cells["N8"].Value = 33.12;
                ws.Cells["O8"].Value = new DateTime(2010, 6, 28);
    
                ws.Cells["K9"].Value = "Screwdriver";
                ws.Cells["L9"].Value = "Hardware";
                ws.Cells["M9"].Value = 1200;
                ws.Cells["N9"].Value = 45.2;
                ws.Cells["O9"].Value = new DateTime(2010, 8, 31);
    
                ws.Cells["K10"].Value = "Apple";
                ws.Cells["L10"].Value = "Groceries";
                ws.Cells["M10"].Value = 807;
                ws.Cells["N10"].Value = 1.2;
                ws.Cells["O10"].Value = new DateTime(2010, 9, 30);
    
                ws.Cells["K11"].Value = "Butter";
                ws.Cells["L11"].Value = "Groceries";
                ws.Cells["M11"].Value = 52;
                ws.Cells["N11"].Value = 7.2;
                ws.Cells["O11"].Value = new DateTime(2010, 10, 31);
                ws.Cells["O2:O11"].Style.Numberformat.Format = "yyyy-MM-dd";
    
                var pt = wsPivot1.PivotTables.Add(wsPivot1.Cells["A1"], ws.Cells["K1:N11"], "Pivottable1");
    
                pt.Compact = true;
                pt.CompactData = true;
    
                pt.GrandTotalCaption = "Total amount";
                pt.RowFields.Add(pt.Fields[1]);
                pt.RowFields.Add(pt.Fields[0]);
                pt.DataFields.Add(pt.Fields[3]);
                pt.DataFields.Add(pt.Fields[2]);
                pt.DataFields[0].Function = DataFieldFunctions.Product;
                pt.DataOnRows = false;
    
    
             
                _pck.Workbook.CreateVBAProject();
                
                var sb = new StringBuilder();
    
                sb.AppendLine("Private Sub Workbook_Open()");
                sb.AppendLine("    Range(\"A1\").Select");
                sb.AppendLine("    ActiveSheet.PivotTables(\"Pivottable1\").PivotFields(\"Category\").PivotItems(\"Hardware\").ShowDetail = False");
                sb.AppendLine("End Sub");
                
                _pck.Workbook.CodeModule.Code = sb.ToString();
    
                _pck.Save();
    
                          
            }
            
        }
    }
