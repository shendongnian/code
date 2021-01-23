    void Main()
    {
        using (var reader = new StreamReader("path\\to\\file.csv"))
        using (var csv = new CsvReader(reader, 
               System.Globalization.CultureInfo.CreateSpecificCulture("enUS")))
        {
            var records = csv.GetRecords<Foo>();
        }
    }
