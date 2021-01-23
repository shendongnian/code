    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Documents;
    using NPOI.HSSF.UserModel;
    
    namespace listFloatToExcel
    {
        [...]
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                //list of floats
                List<float> f = new List<float>();
                f.Add(4.323F);
                f.Add(34.54F);
                f.Add(12.4F);
                f.Add(454F);
                f.Add(0987.32F);
    
                // Create a new workbook and a sheet named "Floats"
                var workbook = new HSSFWorkbook();
                var sheet = workbook.CreateSheet("Floats");
    
                var rowIndex = 0;
                foreach (var n in f)
                {
                    var row = sheet.CreateRow(rowIndex);
                    row.CreateCell(0).SetCellValue(n);
                    rowIndex++;
                }
    
                using (var fileData = new FileStream(@"C:\temp\listFloatToExcel\floats.xls", FileMode.Create))
                {
                    workbook.Write(fileData);
                }
           }
            
        [...]
    }
