    public static float ReadFromXml(string f, string n)
    {
        string quantityInIssueUnit;
        XmlReader reader = XmlReader.Create(f);
        reader.ReadToFollowing(n);
        quantityInIssueUnit = reader.ReadInnerXml( );
        reader.Close( );
        return float.Parse(quantityInIssueUnit);
    }
