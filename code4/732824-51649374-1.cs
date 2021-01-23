    public class test{
            private dynamic ExcelObject;
            protected dynamic ExcelBook;
            protected dynamic ExcelBooks;
            protected dynamic ExcelSheet;
    
    public void LoadExcel(string FileName)
            {
                Type t = Type.GetTypeFromProgID("Excel.Application");
                if (t == null) throw new Exception("Excel non installato");
                ExcelObject = System.Activator.CreateInstance(t);
                ExcelObject.Visible = false;
                ExcelObject.DisplayAlerts = false;
                ExcelObject.AskToUpdateLinks = false;
                ExcelBooks = ExcelObject.Workbooks;
                ExcelBook = ExcelBooks.Open(FileName,0,true);
                System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                ExcelSheet = ExcelBook.Sheets[1];
            }
     private void ReleaseObj(object obj)
            {
                try
                {
                    int i = 0;
                 while(   System.Runtime.InteropServices.Marshal.ReleaseComObject(obj) > 0)
                    {
                        i++;
                        if (i > 1000) break;
                    }
                    obj = null;
                }
                catch 
                {
                    obj = null;
                }
                finally
                {
                    GC.Collect();
                }
            }
            public void ChiudiExcel() {
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
    
                ReleaseObj(ExcelSheet);
                try { ExcelBook.Close(); } catch { }
                try { ExcelBooks.Close(); } catch { }
                ReleaseObj(ExcelBooks);
                try { ExcelObject.Quit(); } catch { }
                ReleaseObj(ExcelObject);
            }
    }
