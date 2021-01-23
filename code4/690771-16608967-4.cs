    public Record ParseRecord(string[] fields) {
        if (fields.Length < SomeLineLength)
            throw new MalformadLineException(...)
        var record = new Record();
    
        record.Field1 = int.Parse(fields[0], NumberFormat.None, CultureInvoice.InvariantCulture);
        record.Field2 = DateTime.ParseExact(fields[1], "yyyyMMdd", CultureInvoice.InvariantCulture);
        if (fields[2] != "")
            record.PossibleEmptyField3 = decimal.Parse(fields[2]...)
     
        return record;
    }
