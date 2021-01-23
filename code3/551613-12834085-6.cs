    public void WriteAccounts(IEnumerable<Account> data, TextWriter target)
    {
        // Use XmlSerializerNamespaces to supress xmlns:xsi and xmlns:xsd
        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add("", "");
        var ser = new XmlSerializer(typeof(Account));
    
        using (var writer = XmlWriter.Create(target))
        {
            writer.WriteStartElement("BillingFile");
            
            foreach (var acct in data)
            {
                ser.Serialize(writer, acct, namespaces);
            }
            
            writer.WriteEndElement();
        }
    }
