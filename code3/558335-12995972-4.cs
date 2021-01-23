    using Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    ...
         static void Main(string[] args)
                {
                    Application application = new Application();
                    application.Visible = false;
                    string filePath = @"C:\excel.xlsx";
                    var book = application.Workbooks.Open(filePath, Type.Missing, true);
                    Workbook workBook = application.Workbooks.Open(filePath,
                                                                    Type.Missing, true, Type.Missing, Type.Missing,
                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                                    Type.Missing, Type.Missing);
            
                    foreach (Worksheet item in workBook.Sheets)
                    {
                        foreach (Range cell in item.Cells)
                        {
                            //Navigate huge options... 
                            //.Borders
                            //.Style
                            //... 
                        }
                
                    }
            
                    workBook.Close(false, filePath, null);
                    Marshal.ReleaseComObject(workBook);
                    application.Quit();
                    Console.ReadLine();
                }
