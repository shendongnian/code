    public IEnumerable<Account> ReadAccounts(TextReader source)
    {
        var ser = new XmlSerializer(typeof(Account));
        using (var reader = XmlReader.Create(source))
        {
            if (!reader.IsStartElement("BillingFile"))
            {
                yield break;
            }
    
            reader.Read();
            while (reader.MoveToContent() == XmlNodeType.Element)
            {
                yield return (Account) ser.Deserialize(reader);
            }
        }
    }
