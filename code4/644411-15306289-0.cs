    private static object _key = new object();
    
    [WebMethod]
    public static bool saveToCSV(string[] valueArray)
    {
       ...
       lock (_key) { 
        using (StreamWriter sw = new StreamWriter(filePath + "\\spreadsheet.csv")) {
          ...
        }
       }
    }
