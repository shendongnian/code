            var ExcelApp = new Excel.Application();
            ExcelApp.Visible = true;
            Excel.Workbook wb = ExcelApp.Workbooks.Add();
            // put some data in it
            for (int i = 1; i <= 10; i++)
            {
                ExcelApp.Cells[i, 1] = "Item " + i;
            }
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(ExcelApp.Cells[i, 1].Value);
            }
            Console.ReadKey();
