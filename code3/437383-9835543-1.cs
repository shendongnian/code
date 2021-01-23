    namespace So9817628
    {
        using System.Data;
        using System.Text;
        using Gorgon.Parsing.Csv;
    
        class Program
        {
            static void Main(string[] args)
            {
                // prepare
                CsvParserSettings s = new CsvParserSettings();
                s.CodePage = Encoding.Default;
                s.ContainsHeader = false;
                s.SplitString = ",";
                s.EscapeString = "\"\"";
                s.ContainsQuotes = true;
                s.ContainsMultilineValues = true;
                // uncomment below if you don't want escape quotes ("") to be replaced with single quote
                //s.ReplaceEscapeString = false;
    
                CsvParser parser = new CsvParser(s);
    
                DataTable dt = parser.ParseToDataTableSequential("multiline_quotes.txt");
    
                dt.WriteXml("parsed.xml");
            }
        }
    }
