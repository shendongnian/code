    public IEnumerable<Person> ReadFromCsv(string csvFile) {
        //Here you set some properties. Check the documentation.
        var csvFileDescription = new CsvFileDescription
        {
            FirstLineHasColumnNames = true,
            SeparatorChar = ',' //Specify the separator character.
        };
        
        var csvContext = new CsvContext();
        return new csvContext.Read<Person>(csvFile, csvFileDescription);
    }
