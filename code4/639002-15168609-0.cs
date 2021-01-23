    foreach (string line in File.ReadLines(filePath))
    {
        if( line.StartsWith("Date:  "))
        {
            result.Rows.Add(line);
        }
        else if (line.StartsWith("Time:  "))
        {
            result.Rows.Add(line);
        }
        else if (line.StartsWith("Seconds"))
        {
           break;
        }
    }
