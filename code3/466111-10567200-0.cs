     public class Reader : IDataReader
        {
            readonly StreamReader _streamReader;
     
            readonly Func<string, object>[] _convertTable;
            readonly Func<string, bool>[] _constraintsTable;
     
            string[] _currentLineValues;
            string _currentLine;
     
            //Constructing reader you can specify your converters     
            public Reader(string filepath, Func<string, bool>[] constraintsTable, Func<string, object>[] convertTable)
            {
                _constraintsTable = constraintsTable;
                _convertTable = convertTable;
                _streamReader = new StreamReader(filepath);
     
                _currentLine = null;
                _currentLineValues = null;
            }
     
                 
            public object GetValue(int i)
            {
                try
                {
                    return _convertTable[i](_currentLineValues[i]);
                }
                catch (Exception)
                {
                    return null;
                }
            }
     
               
            public bool Read()
            {
                if (_streamReader.EndOfStream) return false;
     
                _currentLine = _streamReader.ReadLine();
     
               
                _currentLineValues = _currentLine.Split(/*any column splitter*/);
     
                var invalidRow = false;
                for (int i = 0; i < _currentLineValues.Length; i++)
                {
                    if (!_constraintsTable[i](_currentLineValues[i]))
                    {
                        invalidRow = true;
                        break;
                    }
                }
     
                return !invalidRow || Read();
            }
 
    //other methods...
    }
