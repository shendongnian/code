    IEnumerable<IDataLine> GetLines<T>(IParser parser)
    {
       ...
       if (!parser.CanParse(line))
       {
            continue;
       }
       var dataLine = parser.Parse(line);
       ...
    }
