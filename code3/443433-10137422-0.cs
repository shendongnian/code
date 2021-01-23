    FileInfo fi = new FileInfo(@"c:\Book1.xlsx");
    using (ExcelPackage package = new ExcelPackage(fi))
    {
        // add a new worksheet to the empty workbook
        ExcelWorksheet worksheet = package.Workbook.Worksheets["Inv"];
        //add multi-coloured text to a cell
        worksheet.Cells[2, 1].IsRichText = true;
        ExcelRichTextCollection rtfCollection = worksheet.Cells[2, 1].RichText;
        ExcelRichText ert = rtfCollection.Add("bugaga");
        ert.Bold = true;
        ert.Color = System.Drawing.Color.Red;
        ert.Italic = true;
        ert = rtfCollection.Add("alohaaaaa");
        ert.Bold = true;
        ert.Color = System.Drawing.Color.Purple;
        ert.Italic = true;
        ert = rtfCollection.Add("mm");
        ert.Color = System.Drawing.Color.Peru;
        ert.Italic = false;
        ert.Bold = false;
        package.Save();
    }
