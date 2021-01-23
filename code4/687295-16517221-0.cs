    using System.Data;
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable("test");
            table.Columns.Add();
            table.Columns.Add();
            table.Rows.Add("1", "2");
            table.Rows.Add("3", "4");
            ClosedXML.Excel.XLWorkbook workbook = new ClosedXML.Excel.XLWorkbook();
            workbook.Worksheets.Add(table);
            workbook.SaveAs("D:\\test.xlsx");
        }
    }
