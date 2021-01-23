    // Skip rows.
    csvReader.Configuration.IgnoreBlankLines = false;
    csvReader.Configuration.IgnoreQuotes = true;
    for (var i = 0; i < 10; i++)
    {
    	csvReader.Read();
    }
    csvReader.Configuration.IgnoreBlankLines = false;
    csvReader.Configuration.IgnoreQuotes = false;
    // Carry on as normal.
    var myData = csvReader.GetRecords<MyCustomType>;
