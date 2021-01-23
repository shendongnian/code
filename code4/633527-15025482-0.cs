                // try to open excel
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Type typeExcelApplication = Type.GetTypeFromProgID("Excel.Application");
                if (typeExcelApplication == null)
                    throw new Exception("Excel is not installed (Excel.Application is not found)");
                object objExcelApplication = Activator.CreateInstance(typeExcelApplication);
                object objWorkBooks = objExcelApplication.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, objExcelApplication, null);
                object objWorkBook = objWorkBooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, objWorkBooks, null);
                object objWorkSheet = objWorkBook.GetType().InvokeMember("ActiveSheet", BindingFlags.GetProperty, null, objWorkBook, null);
                // fill data (put object obj into cell [1,1])
                objWorkSheet.GetType().InvokeMember("Cells", BindingFlags.SetProperty, null, objWorkSheet, new object[] { 1, 1, obj});
                // display excel
                typeExcelApplication.InvokeMember("Visible", BindingFlags.SetProperty, null, objExcelApplication, new object[] { true });
                Marshal.ReleaseComObject(objExcelApplication);
