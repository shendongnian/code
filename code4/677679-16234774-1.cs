    var subjectString = "one two \"three four\" five \"six seven\"";
    using (var csvReader = CsvReader.FromCsvString(subjectString))
    {
        csvReader.ValueSeparator = ' ';
        csvReader.ValueDelimiter = '"';
        while (csvReader.HasMoreRecords)
        {
            var record = csvReader.ReadDataRecord();
            Console.WriteLine(record[2]);
        }
    }
