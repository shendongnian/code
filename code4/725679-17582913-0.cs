    Excel.Application eApp = null;
                Excel.Workbook eBook = null;
                    eApp = new Excel.Application();
    
                    eBook = eApp.Workbooks.Open(pathToFile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    
                    var docProp = eBook.BuiltinDocumentProperties("Creation Date");
                    System.DateTime dt = docProp.Value;
                    MessageBox.Show(dt.ToLongTimeString());
