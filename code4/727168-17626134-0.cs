    public class CSVResult : FileResult
    {
        private IQueryable _data;
        private string[] _headers;
    
        public CSVResult(string fileName, IQueryable data)
            : base("text/csv")
        {
            this.FileDownloadName = fileName;
            _data = data;
        }
           
        public CSVResult(string fileName, IQueryable data, string[] headers)
            : this(fileName, data)
        {
            _headers = headers;
        }
    
        // Returns a string array containing the headers (column names) 
        private string[] GetHeaders()
        {
            var headers = (from p in _data.ElementType.GetProperties()
                            select p.Name).ToArray();
    
            return headers;
        }
            
        // Writes the CSV file to the http response 
        protected override void WriteFile(HttpResponseBase response)
        {
            Stream outputStream = response.OutputStream;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                WriteObject(memoryStream);
                outputStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
        }
    
        // Writes the CSV data into a stream
        private void WriteObject(Stream stream)
        {
            StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Default);
    
            if (_headers == null)
            {
                _headers = GetHeaders();
            }
    
            // First line for column names                        
            foreach (var h in _headers)
            {
                writer.Write(string.Format("\"{0}\",", h));
            }
    
            writer.WriteLine();
    
            foreach (var row in _data)
            {
                foreach (var p in row.GetType().GetProperties())
                {
                    var value = p.GetValue(row, null);
                    string strValue = value == null ? string.Empty : value.ToString();
    
                    writer.Write(string.Format("\"{0}\",", strValue));
                }
    
                writer.WriteLine();
            }
    
            writer.Flush();
        }
    }
