    public byte[] GetExcelApplication(Guid sessionKey)
    {
        // Input checking
        using (var workbook = new XLWorkbook(_excelFile))
        {
            var worksheets = workbook.Worksheets.Where(w => w.Name == "Session Key");
            if (worksheets.Count() < 1)
                throw new Exception("Excel file does not contain a worksheet called: Session Key");
            if (worksheets.Count() > 1)
                throw new Exception("Excel file contains multiple worksheets called: Session Key");
            var worksheet = worksheets.Single();
            var cell = worksheet.Cell("A1").Value = sessionKey.ToString();
            using (var ms = new MemoryStream())
            {
                workbook.SaveAs(ms);
                return ms.ToArray();
            }
        }
    }
