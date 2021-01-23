    // A class that can read and parse the data in a CSV file.
    public class CSVReader
    {
        // Regex expression that's used to parse the data in a line of a CSV file
        private const string ESCAPE_SPLIT_REGEX = "({1}[^{1}]*{1})*(?<Separator>{0})({1}[^{1}]*{1})*";
        // String array to hold the headers (column names)
        private string[] _headers;
        // List of string arrays to hold the data in the CSV file. Each string array in the list represents one line (row).
        private List<string[]> _rows;
        // The StreamReader class that's used to read the CSV file.
        private StreamReader _reader;
        public CSVReader(StreamReader reader)
        {
            _reader = reader;
            Parse();
        }
        // Reads and parses the data from the CSV file
        private void Parse()
        {
            _rows = new List<string[]>();
            string[] row;
            int rowNumber = 1;
            var headerLine = "RowNumber," + _reader.ReadLine();
            _headers = GetEscapedSVs(headerLine);
            rowNumber++;
            while (!_reader.EndOfStream)
            {
                var line = rowNumber + "," + _reader.ReadLine();
                row = GetEscapedSVs(line);
                _rows.Add(row);
                rowNumber++;
            }
            _reader.Close();
        }
        private string[] GetEscapedSVs(string data)
        {
            if (!data.EndsWith(","))
                data = data + ",";
            return GetEscapedSVs(data, ",", "\"");
        }
        // Parses each row by using the given separator and escape characters
        private string[] GetEscapedSVs(string data, string separator, string escape)
        {
            string[] result = null;
            int priorMatchIndex = 0;
            MatchCollection matches = Regex.Matches(data, string.Format(ESCAPE_SPLIT_REGEX, separator, escape));
            // Skip empty rows...
            if (matches.Count > 0) 
            {
                result = new string[matches.Count];
                
                for (int index = 0; index <= result.Length - 2; index++)
                {
                    result[index] = data.Substring(priorMatchIndex, matches[index].Groups["Separator"].Index - priorMatchIndex);
                    priorMatchIndex = matches[index].Groups["Separator"].Index + separator.Length;
                }
                result[result.Length - 1] = data.Substring(priorMatchIndex, data.Length - priorMatchIndex - 1);
                for (int index = 0; index <= result.Length - 1; index++)
                {
                    if (Regex.IsMatch(result[index], string.Format("^{0}.*[^{0}]{0}$", escape))) 
                        result[index] = result[index].Substring(1, result[index].Length - 2);
                    
                    result[index] = result[index].Replace(escape + escape, escape);
                    if (result[index] == null || result[index] == escape) 
                        result[index] = "";
                }
            }
            return result;
        }
        // Returns the number of rows
        public int RowCount
        {
            get
            {
                if (_rows == null)
                    return 0;
                return _rows.Count;
            }
        }
        // Returns the number of headers (columns)
        public int HeaderCount
        {
            get
            {
                if (_headers == null)
                    return 0;
                return _headers.Length;
            }
        }
        // Returns the value in a given column name and row index
        public object GetValue(string columnName, int rowIndex)
        {
            if (rowIndex >= _rows.Count)
            {
                return null;
            }
            var row = _rows[rowIndex];
            int colIndex = GetColumnIndex(columnName);
            if (colIndex == -1 || colIndex >= row.Length)
            {
                return null;
            }
            var value = row[colIndex];
            return value;
        }
        // Returns the column index of the provided column name
        public int GetColumnIndex(string columnName)
        {
            int index = -1;
            for (int i = 0; i < _headers.Length; i++)
            {
                if (_headers[i].Replace(" ","").Equals(columnName, StringComparison.CurrentCultureIgnoreCase))
                {
                    index = i;
                    return index;
                }
            }
            return index;
        }
    }
