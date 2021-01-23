    FileInfo fi = new FileInfo(@"c:\Book1.xlsx");
    
          using (ExcelPackage package = new ExcelPackage(fi))
          {
            // add a new worksheet to the empty workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets["Inv"];
            //Add the headers
    
            worksheet.Cells[2, 1].IsRichText = true;
            ExcelRichText ert = worksheet.Cells[2, 1].RichText.Add("bugaga");
            ert.Bold = true;
            ert.Color = System.Drawing.Color.Red;
            ert.Italic = true;
    
            ert = worksheet.Cells[2, 1].RichText.Add("alohaaaaa");
            ert.Bold = true;
            ert.Color = System.Drawing.Color.Purple;
            ert.Italic = true;
    
            ert = worksheet.Cells[2, 1].RichText.Add("mm");
            ert.Color = System.Drawing.Color.Peru;
            ert.Italic = false;
            ert.Bold = false;
    
    
            package.Save();
          }
