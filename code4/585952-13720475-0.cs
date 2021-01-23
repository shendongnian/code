    public class MyRow
    {
       public string Cell1;
       public string Cell2;
       public string Cell3;
    }
    class Program
    {
            static void Main()
            {
                var list = new List<MyRow>();
                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                //...
                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
               
                //5. Data Reader methods
                while (excelReader.Read())
                {
                       var obj = new MyRow 
                       {
                           Cell1 = excelReader.GetString(0),
                           Cell2 = excelReader.GetString(1),
                           Cell3 = excelReader.GetString(2),
                       }
                       list.Add(obj);
                }
                //6. Free resources (IExcelDataReader is IDisposable)
                excelReader.Close();
                var json = new JavaScriptSerializer().Serialize(list);
                Console.WriteLine(json);
            }
        }
