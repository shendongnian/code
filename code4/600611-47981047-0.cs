      using (var target = new ExcelPackage(new System.IO.FileInfo("D:\\target.xls")))
            {
                target.Workbook.Worksheets.Add("worksheet");
                target.Workbook.Worksheets.Last().Cells["A1:A12"].Value = "Hi";
                target.Save();
            }
