    public interface IFileParser
    {
        void perse(string fileToParse);
    }
        public static class FileParserFactory
        {
            public static IFileParser GetParser(string fileToParse)
            {
                FileInfo file = new FileInfo(fileToParse);
                IFileParser parserToReturn = null;
                switch (file.Extension.ToLower())
                {
                    case "csv": parserToReturn = new CSVFileParser(fileToParse);
                        break;
                    case "txt": parserToReturn = new TextFileParser(fileToParse);
                        break;
                }
                return parserToReturn;
            }
        }
