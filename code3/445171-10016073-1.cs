    string line = <YourLine>
    var result = new StringBuilder();
    var inQuotes = false;
    foreach(char c in line)
    {
        switch (c)
        {
            case '"':
            case '\'':
                result.Append()
                inQuotes = !inQuotes;
                break;
            case ',':
                if (!inQuotes)
                {
                    yield return result.ToString();
                    result.Clear();
                }
              
            default:
                result.Append()
                break;                
        }
    }
