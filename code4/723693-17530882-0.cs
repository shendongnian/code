    DataTable tblCSV = new DataTable("CSV");
    var fileInfo = new System.IO.FileInfo(fullPath);
    var encoding = Encoding.GetEncoding(437); // use the correct encoding
    using (var reader = new System.IO.StreamReader(fullPath, encoding))
    {
        //reader.ReadLine(); // skip all lines but header+data
        Char quotingCharacter = '\0';//'"';
        Char escapeCharacter = quotingCharacter;
        using (var csv = new CsvReader(reader, true, Importer.FieldDelimiter, quotingCharacter, escapeCharacter, '\0', ValueTrimmingOptions.All))
        {
            csv.MissingFieldAction = MissingFieldAction.ParseError;
            csv.DefaultParseErrorAction = ParseErrorAction.RaiseEvent;
            csv.ParseError += csv_ParseError;
            csv.SkipEmptyLines = true;
            try
            {
                // load into DataTable
                tblCSV.Load(csv, LoadOption.OverwriteChanges, csvTable_FillError);
