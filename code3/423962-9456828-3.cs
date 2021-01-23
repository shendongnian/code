    public FileParseException(string fileName, long lineNumber)
        : base(
            string.Format(
                "Error while parsing file {0} on line {1}.",
                fpe.FileName, fpe.LineNumber))
    {
        FileName = fileName;
        LineNumber = lineNumber;
    }
