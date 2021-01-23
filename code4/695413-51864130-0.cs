        public static void convertToExcel(string fileName, string splitter, string extension)
        {
            string newFileName = fileName.Replace("." + extension, ".xls");
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            int columnCounter = 0;
            
            foreach (string s in lines)
            {
                string[] ss = s.Trim().Split(Convert.ToChar(splitter));
                if (ss.Length > columnCounter)
                    columnCounter = ss.Length;
            }           
            HSSFWorkbook workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("Data");
            var rowIndex = 0;
            var rowExcel = sheet.CreateRow(rowIndex);
            foreach (string s in lines)
            {
                rowExcel = sheet.CreateRow(rowIndex);
                string[] ss = s.Trim().Split(Convert.ToChar(splitter));
                for (int i = 0; i < columnCounter; i++)
                {
                    string data = !String.IsNullOrEmpty("s") && i < ss.Length ? ss[i] : "";
                    rowExcel.CreateCell(i).SetCellType(CellType.String);
                    rowExcel.CreateCell(i).SetCellValue(data);                    
                }
                rowIndex++;
            }
            for (var i = 0; i < sheet.GetRow(0).LastCellNum; i++)
                sheet.AutoSizeColumn(i);
            using (FileStream file = new FileStream(newFileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(file);
                file.Close();
            }
        }
