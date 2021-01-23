    private validateRecievedXmlCallback(IAsyncResult ar)
    {
        string sPattern = '^<test([^>]*) \/>$';
        if (System.Text.RegularExpressions.Regex.IsMatch(xmlData, sPattern))
        {
            return(true);
        }
        return(xmlData.IndexOf('</test>') !== -1);
    }
