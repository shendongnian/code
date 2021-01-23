    public void WriteAccounts(IEnumerable<Account> data, TextWriter target)
    {
        var ser = new XmlSerializer(typeof(Account));
    
        using (var writer = XmlWriter.Create(target))
        {
            writer.WriteStartElement("BillingFile");
            
            foreach (var acct in data)
            {
                ser.Serialize(writer, acct);
            }
            
            writer.WriteEndElement();
        }
    }
