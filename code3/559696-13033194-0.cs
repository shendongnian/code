    string arguments = Console.ReadLine();
    TextFieldParser parser = new TextFieldParser(new StringReader(arguments));
    parser.Delimiters = new[] { " " };
    parser.HasFieldsEnclosedInQuotes = true;
    string[] parsedArguments = parser.ReadFields();
