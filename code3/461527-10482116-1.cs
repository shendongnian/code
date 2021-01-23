        void excel_WorkbookOpen(Excel.Workbook wb)
        {
            if (!wb.FullName.Equals(pathToExcelFile)) // pathToExcelFile is class-wide visible
            {
                return;
            }
            Console.WriteLine("done it right");
        }
