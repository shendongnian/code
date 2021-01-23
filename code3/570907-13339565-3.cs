    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using OfficeOpenXml;
    using System.IO;
    using OfficeOpenXml.Drawing.Chart;
    
    namespace TestExcelEPPluss
    {
        class Program
        {
            static void Main(string[] args)
            {
                ExcelPackage package = new ExcelPackage();
                var sheet = package.Workbook.Worksheets.Add("TestingGraph");
    
                Random r = new Random();
                var cell = sheet.Cells["A1"];
                cell.Value = "Before";
    
                cell = sheet.Cells["B1"];
                cell.Value = "After";
    
                for (int i = 0; i < 100; i++)
                {
                    cell = sheet.Cells[i + 2, 1];
                    cell.Value = r.Next(300, 500);
                    cell = sheet.Cells[i + 2, 2];
                    cell.Value = r.Next(300, 500);
                }
    
                ExcelChart ec = (ExcelLineChart)sheet.Drawings.AddChart("chart_1", eChartType.Line);
                ec.SetPosition(1, 0, 3, 0);
                ec.SetSize(800, 300);
                //ec.Legend.Add();
    
                var ran1 = sheet.Cells["A2:A101"];
                var ran2 = sheet.Cells["0:0"];
    
                var serie1 = (ExcelLineChartSerie)ec.Series.Add(ran1, ran2);
                serie1.Header = sheet.Cells["A1"].Value.ToString();
    
                ran1 = sheet.Cells["B2:B101"];
                var serie2 = ec.Series.Add(ran1, ran2);
                serie2.Header = sheet.Cells["B1"].Value.ToString();
    
                var xml = ec.ChartXml;
                var lst = xml.GetElementsByTagName("c:lineChart");
                foreach (System.Xml.XmlNode item in lst[0].ChildNodes)
                {
                    if (item.Name.Equals("ser"))
                    {
                        foreach (System.Xml.XmlNode subitem in item.ChildNodes)
                        {
                            if (subitem.Name.Equals("c:cat"))
                            {
                                item.RemoveChild(subitem);
                                break;
                            }
                        }
                    }
                }
    
                string path = @"C:\test1.xlsx";
                File.WriteAllBytes(path, package.GetAsByteArray());
                package.Dispose();
    
                Console.WriteLine("Done - Path: {0}", path);
                Console.ReadLine();
            }
        }
    }
