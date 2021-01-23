    public class MyClass
    {
        // Lots of code....
        private static Regex regexRowExtract(@"^\s*(?<ip>\d+\.\d+\.\d+\.\d+)\s*(?<value>\d+)\s+(?<rate>\d+\.?\d*)\s+(?<percentage>\d+\.?\d*)%\s*$", RegexOptions.Compiled);
        public void ReadSharkData()
        {
            using(StreamReader reader = tsharkProcess.StandardOutput)
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    Match match = regexRowExtract.Match(row);
                    if (match.Success)
                    {
                        string ipAddress = match.Groups["ip"].Value;
                        string value = match.Groups["value"].Value;
                        string percentage = match.Groups["percentage"].Value;
                        // Processing the extracted data ...
                    }
                }
            }
        }
    }
