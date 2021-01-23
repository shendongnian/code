    public bool ValidateIPv4(string ipString)
    {
        if (String.IsNullOrWhiteSpace(ipString))
        {
            return false;
        }
        string[] splitValues = ipString.Split('.');
        if (splitValues.Length != 4)
        {
            return false;
        }
        byte tempForParsing;
        return splitValues.All(r => byte.TryParse(r, out tempForParsing));
    }
