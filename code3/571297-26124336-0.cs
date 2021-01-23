    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using NPOI.Util.Collections;
    using NPOI;
    using System.Collections.Generic;
    using NPOI.OpenXmlFormats.Spreadsheet;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.Util;
    public DataTable xlsxToDT(Stream str)
    {
    XSSFWorkbook hssfworkbook = new XSSFWorkbook(str);
    ISheet sheet = hssfworkbook.GetSheetAt(0);
    str.Close();
    DataTable dt = new DataTable();
    IRow headerRow = sheet.GetRow(0);
    IEnumerator rows = sheet.GetRowEnumerator();
    int colCount = headerRow.LastCellNum;
    int rowCount = sheet.LastRowNum;
    for (int c = 0; c < colCount; c++)
        dt.Columns.Add(headerRow.GetCell(c).ToString());
    while (rows.MoveNext())
    {
        IRow row = (XSSFRow)rows.Current;
        DataRow dr = dt.NewRow();
        for (int i = 0; i < colCount; i++)
        {
            ICell cell = row.GetCell(i);
            if (cell != null)
                dr[i] = cell.ToString();
        }
        dt.Rows.Add(dr);
    }
    return dt;
}
