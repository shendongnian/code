        FileStream fs = new FileStream(templateName, FileMode.Open, FileAccess.Read);
        HSSFWorkbook workbook = new HSSFWorkbook(fs);
        Sheet sheet1 = workbook.GetSheet("Sheet1");
        List<string> items = new List<string>();
        for (int i = 1; i <= sheet1.LastRowNum; i++)
        {
            string item = sheet1.GetRow(i).GetCell(0).ToString();
            items.Add(item);
        }
