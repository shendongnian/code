    public static List<string> GetCellValue(string fileName, string sheetName, string addressName)
        {
            List<string> result = new List<String>;
            object hmissing = System.Reflection.Missing.Value;
            Application app = new ApplicationClass();
            Workbook aWb = app.Workbooks.Open(fileName, hmissing, hmissing, hmissing, hmissing,
                hmissing, hmissing, hmissing, hmissing, hmissing, hmissing, hmissing, hmissing, hmissing,
                hmissing);
            Worksheet aWs = aWb.Worksheets[sheetName] as Worksheet;
            object[,] values = aWs.UsedRange.get_Value(hmissing) as object[,];
            foreach (object anObj in values)
                 if (anObj != null)
                     result.Add(anObj.ToString());  
            aWb.Close(false, hmissing, hmissing);
            app.Quit();          
            return result;
        }
