    string sText = File.ReadAllText(@"c:\file.txt");
    sText = removeLines(sText);
    public string removeLines(string sData) {
                string[] sArray = sData.Split(sDelim, 
                                              StringSplitOptions.RemoveEmptyEntries);
                StringBuilder builder = new StringBuilder();
                foreach (string value in sArray)
                {
                    builder.Append(value);
                    builder.Append("\r\n");
                }
                return builder.ToString();
    }
