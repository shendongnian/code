    class Program
    {
    static XSSFWorkbook hssfworkbook;
    static DataSet dataSet1 = new DataSet();
    static void Main(string[] args)
    {
        InitializeWorkbook(@"E:\Docs\HoursWidget_RTM.xlsx");
        xlsxToDT();
        DisplayData(dataSet1.Tables[0]);
        Console.ReadLine();
    }
    static void InitializeWorkbook(string path)
    {
        using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            hssfworkbook = new XSSFWorkbook(file);
        }
    }
    static void xlsxToDT()
    {
        DataTable dt = new DataTable();
        ISheet sheet = hssfworkbook.GetSheetAt(1);
        IRow headerRow = sheet.GetRow(0);
        IEnumerator rows = sheet.GetRowEnumerator();
        int colCount = headerRow.LastCellNum;
        int rowCount = sheet.LastRowNum;
        for (int c = 0; c < colCount; c++)
        {
            dt.Columns.Add(headerRow.GetCell(c).ToString());
        }
        bool skipReadingHeaderRow = rows.MoveNext();
        while (rows.MoveNext())
        {
            IRow row = (XSSFRow)rows.Current;
            DataRow dr = dt.NewRow();
            for (int i = 0; i < colCount; i++)
            {
                ICell cell = row.GetCell(i);
                if (cell != null)
                {
                    dr[i] = cell.ToString();
                }
            }
            dt.Rows.Add(dr);
        }
        hssfworkbook = null;
        sheet = null;
        dataSet1.Tables.Add(dt);
    }
    static void DisplayData(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn col in table.Columns)
            {
                Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
            }
            Console.WriteLine("-------------------------------------------");
        }
    }
    }
