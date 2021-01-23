    List<CSVFile> entries = new List<CSVFile>();
    using (TextFieldParser parser = new TextFieldParser(@"C:\CSVDATA\PreviousYear.csv"))
    {
        parser.TextFieldType = FieldType.Delimited;
        parser.Delimiters = new string[]{','};
        string[] fields;
        while (!parser.EndOfData)
        {
            fields = parser.ReadFields();
            entries.Add(new CSVFile() { Request_ID = Convert.ToInt32(fields[0]), 
                                        Priority = Convert.ToInt32(fields[1]),
                                        Module_ID = Convert.ToInt32(fields[2]),
                                        Day = fields[3],
                                        Start_Time = fiedls[4],
                                        // and the rest of the properties, casting as needed
                                       };
        }
    }
