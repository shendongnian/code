    public IEnumerable<Account> ReadAccounts(TextReader source)
    {
        var reader = XmlReader.Create(source);
        if (!reader.IsStartElement("BillingFile"))
        {
            yield break;
        }
        
        reader.Read();
        
        var ser = new XmlSerializer(typeof(Account));
        while (reader.MoveToContent() == XmlNodeType.Element)
        {
            yield return (Account) ser.Deserialize(reader);
        }
    }
