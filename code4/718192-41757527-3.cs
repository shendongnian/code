                   Microsoft.Office.Interop.Excel.Application app = null;
            Microsoft.Office.Interop.Excel.Workbooks books = null;
            Workbook book = null;
            Sheets sheets = null;
            Worksheet sheet = null;
            Range range = null;
            try
            {
                app = new Microsoft.Office.Interop.Excel.Application();
                books = app.Workbooks;
                book = books.Add();
                sheets = book.Sheets;
                sheet = sheets.Add();
                range = sheet.Range["A1"];
                range.Value = "Lorem Ipsum";
                book.SaveAs(@"C:\Temp\ExcelBook" + DateTime.Now.Millisecond + ".xlsx");
                book.Close();
                app.Quit();
            }
            finally
            {
                if (range != null) Marshal.ReleaseComObject(range);
                if (sheet != null) Marshal.ReleaseComObject(sheet);
                if (sheets != null) Marshal.ReleaseComObject(sheets);
                if (book != null) Marshal.ReleaseComObject(book);
                if (books != null) Marshal.ReleaseComObject(books);
                if (app != null) Marshal.ReleaseComObject(app);
            }
