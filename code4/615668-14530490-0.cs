            Application appExl = new Application();
            Workbook workbook;
            //Opening Excel file(myData.xlsx)
            workbook = appExl.Workbooks.Open(
                @"c:\apps\book1.xlsx",
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value);
            Worksheet sheet = workbook.Sheets.get_Item(1);
            sheet.UsedRange.Copy();
            var a = Clipboard.GetText();
