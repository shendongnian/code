    protected byte[] GetCSVFileContent(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default, true))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            string allines = sb.ToString();
    
    
            UTF8Encoding utf8 = new UTF8Encoding();
    
    
            var preamble = utf8.GetPreamble();
    
            var data = utf8.GetBytes(allines);
    
    
            return data;
        }
