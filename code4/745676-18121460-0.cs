    using Microsoft.VisualBasic.FileIO;
    using (TextFieldParser parser = new TextFieldParser(fileName))
    {
        parser.Delimiters = new string[] { "," };
        while (!parser.EndOfData)
        {
            string[] fields = parser.ReadFields();   
        }
    }
