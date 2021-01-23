    using Microsoft.VisualBasic.FileIO;
    ....
    string[,] parsedCsv;
    List<string[]> csvLines = new List<string[]>();
    TextFieldParser parser = new TextFieldParser(new FileStream(guid.ToString(), FileMode.Open));
    parser.Delimiters = new string[] { "," };
    parser.TextFieldType = FieldType.Delimited;
    int maxLines = 200, lineCount = 0;
    try
    {
        while (!parser.EndOfData && lineCount < maxLines)
        {
            csvLines.Add(parser.ReadFields());
        }
    }
    catch (MalformedLineException)
    {
        Console.WriteLine("Line Number: {0} Value: {1}", parser.ErrorLineNumber, parser.ErrorLine);
        return;
    }
    parsedCsv = new string[csvLines.Count, csvLines[0].Length];
    for (int i = 0; i < csvLines.Count; i++)
    {
        for (int j = 0; j < csvLines[i].Length; j++)
        {
            parsedCsv[i, j] = csvLines[i][j];
        }
    }
