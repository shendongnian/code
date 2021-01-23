    string xmlLine = "[<colors numResults=\"100\" totalResults=\"6806926\">]";
    string pattern = "totalResults=\"";
    int startIndex = xmlLine.IndexOf(pattern);
    if(startIndex >= 0)
    {
        startIndex += pattern.Length;
        int endIndex = xmlLine.IndexOf("\"", startIndex); 
        if(endIndex >= 0)
        {
            string token = xmlLine.Substring(startIndex,endIndex - startIndex);
            // if you want to calculate with it
            int totalResults = int.Parse( token );
        }
    }
