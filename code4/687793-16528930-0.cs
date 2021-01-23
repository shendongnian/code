    String myFilePath = @"c:\test.csv";
    DataTable dt = new DataTable();
    dt.Columns.Add("HAB_CODE");
    dt.Columns.Add("SIZE");
    dt.Columns.Add("COVER");
    using (var myCsvFile = new TextFieldParser(myFilePath)){
        myCsvFile.TextFieldType = FieldType.Delimited;
        myCsvFile.SetDelimiters(",");
        myCsvFile.CommentTokens = new[] { "HEADER", "COMMENT", "TRAILER" };
   
        while (!myCsvFile.EndOfData) {
            string[] fieldArray;
            try {
                fieldArray = myCsvFile.ReadFields();
                dt.Rows.Add(fieldArray);
            }
            catch (Microsoft.VisualBasic.FileIO.MalformedLineException ex) {
                // not a valid delimited line - log, terminate, or ignore
                continue;
            }
        // process values in fieldArray
        }    
    }
