        string key = "";
        if (string.IsNullOrEmpty(headerResponse)) 
        {
            //No header response... handle it ;)
        }
        var replacedString = headerResponse.Replace("ey:", "`");
        string[] splitted = replacedString.Split('`');
        if (splitted.Length > 1)
        {
            string replaced2 = splitted[1].Replace("\r", "");
            string[] splitted2 = replaced2.Split('\n');
            if (splitted2.Length > 0)
            {
                key = splitted2[0].Trim();
            }
            else 
            {
                // '\n' not found
            }
        }
        else 
        {
            // '`' not found
        }
        if (string.IsNullOrEmpty(key))
        {
            //do error correction
        }
        else 
        {
            //everything is fine
        }
