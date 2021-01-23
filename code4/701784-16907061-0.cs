            public ExcelInterop(string thisFileName)
            {
                _excelApp = new Application();
                books = _excelApp.Workbooks;
                workBook  = books.Open(thisFileName,
                       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                       Type.Missing, Type.Missing);
            }
