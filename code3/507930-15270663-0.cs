            Random rnd = new Random();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook wb = xlApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            // Set random data in A column
            for (int i = 1; i < 10; i++)
            {
                ws.Range["A" + i, Type.Missing].Value = rnd.Next(10);
                ws.Range["B" + i, Type.Missing].Value = rnd.Next(10);
            }
            // Set background if value in cell A more than 5
            int rowNum = 0;
            foreach (Excel.Range range in ws.Range["A1", "A10"])
            {
                rowNum++;
                if (range.Value > 5)
                {
                    foreach (Excel.Range rowRange in ws.Range["A" + rowNum, "B" + rowNum])
                    {
                        var colorScale = (Excel.ColorScale)rowRange.FormatConditions.AddColorScale(2);
                        colorScale.ColorScaleCriteria[2].FormatColor.Color = 0x0000FF00;
                    }
                }
            }
            // Save and close file
            wb.SaveAs("C:\\1234567890.xlsx");
            wb.Close(false, Type.Missing, Type.Missing);
            xlApp.Quit();
