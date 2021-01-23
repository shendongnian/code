    StringBuilder buffer = new StringBuilder();
    foreach (var line in File.ReadLines(logfileName))
    {
        if (line.StartsWith("2013-06-19"))
        {
            if (sb.Length > 0)
            {
                ProcessMessage(sb.ToString());
                sb.Clear();
            }
            sb.AppendLine(line);
        }
    }
    // be sure to process the last message
    if (sb.Length > 0)
    {
        ProcessMessage(sb.ToString());
    }
