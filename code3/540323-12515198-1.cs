    TextFieldParser parser = new TextFieldParser(stream);
    parser.TextFieldType = FieldType.FixedWidth;
    parser.SetFieldWidths(3, 5, 12, 6, 10, 7, 10, 11, 8, 7);
    while (!parser.EndOfData)
    {
        //Processing row
        string[] fields = parser.ReadFields();
        // Treat each field appropriately e.g. int.TryParse,
        // remove the "%" then float.TryParse etc.
    }
    parser.Close();
