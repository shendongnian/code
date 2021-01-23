    public static string BytesAsString(float bytes)
    {
        string[] suffix = { "B", "KB", "MB", "GB", "TB" };
        int i;
        double doubleBytes = 0;
        for (i = 0; (int)(bytes / 1024) > 0; i++, bytes /= 1024)
        {
            doubleBytes = bytes / 1024.0;
        }
        return string.Format("{0:0.00} {1}", doubleBytes, suffix[i]);
    }
    public static long StringAsBytes(string bytesString)
    {
        if (string.IsNullOrEmpty(bytesString))
        {
            return 0;
        }
        const long OneKb = 1024;
        const long OneMb = OneKb * 1024;
        const long OneGb = OneMb * 1024;
        const long OneTb = OneGb * 1024;
        double returnValue;
        string suffix = string.Empty;
        if (bytesString.IndexOf(" ") > 0)
        {
            returnValue = float.Parse(bytesString.Substring(0, bytesString.IndexOf(" ")));
            suffix = bytesString.Substring(bytesString.IndexOf(" ") + 1).ToUpperInvariant();
        }
        else
        {
            returnValue = float.Parse(bytesString.Substring(0, bytesString.Length - 2));
            suffix = bytesString.ToUpperInvariant().Substring(bytesString.Length - 2);
        }
            
        switch (suffix)
        {
            case "KB":
                {
                    returnValue *= OneKb;
                    break;
                }
            case "MB":
                {
                    returnValue *= OneMb;
                    break;
                }
            case "GB":
                {
                    returnValue *= OneGb;
                    break;
                }
            case "TB":
                {
                    returnValue *= OneTb;
                    break;
                }
            default:
                {
                    break;
                }
        }
        return Convert.ToInt64(returnValue);
    }
