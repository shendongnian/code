    IEnumerable<IDataLine> GetLines<T>(Func<object> parseFunction)
    {
       ...
       var dataLine = parseFunction(line);
       if (dataLine == null)
       {
           continue;
       }
       ...
    }
