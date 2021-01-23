    foreach(var filePath in logpath)
    {
        var sbRecord = new StringBuilder();
        using(var reader = new StreamReader(filePath))
        {
            do
            {
                var line = reader.ReadLine();
                // check start of the new record lines
                if (Regex.Match(line, datePattern) && sbRecord.Length > 0)
                {
                    // your method for log record
                    HandleRecord(sbRecord.ToString());
                    sbRecord.Clear();
                    sbRecord.AppendLine(line);
                }
                // if no lines were added or datePattern didn't hit
                // append info about current record
                else
                {
                    sbRecord.AppendLine(line);
                }
            } while (!reader.EndOfStream)
        }
    }
