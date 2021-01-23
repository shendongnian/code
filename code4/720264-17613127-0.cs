    public static string getConnectionString(string fileName, bool HDRValue, bool WriteExcel)
    {
        string hdrValue = HDRValue ? "YES" : "NO";
        string writeExcel = WriteExcel ? string.Empty : "IMEX=1";
        return "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + "Extended Properties=\"Excel 12.0 xml;HDR=" + hdrValue + ";" + writeExcel + "\"";
    }
