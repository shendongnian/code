    public IEnumerable<string> GetScriptParts(Stream script)
    {
        const string reBatchSeparator = @"^(/\*.\*/)?\s*GO\s*(/\*.*\*/)?\s*(--.*)?$";
        using (StreamReader sr = new StreamReader(script))
        {
            StringBuilder sb = new StringBuilder();
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (!batchSeparator.IsMatch(line))
                {
                    sb.AppendLine(line);
                }
                else
                {
                    string part = sb.ToString();
                    if (!string.IsNullOrEmpty(part))
                    {
                        yield return part;
                    }
                    sb.Clear();
                }
            }
            string part = sb.ToString();
            if (!string.IsNullOrEmpty(part))
            {
                yield return part;
            }
        }
    }
