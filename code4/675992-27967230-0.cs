    using Microsoft.VisualBasic.FileIO;   //For TextFieldParser
    // blah blah blah
    StringReader csv_reader = new StringReader(csv_line);
    TextFieldParser csv_parser = new TextFieldParser(csv_reader);
    csv_parser.SetDelimiters(",");
    csv_parser.HasFieldsEnclosedInQuotes = true;
    string[] csv_array = csv_parser.ReadFields();
